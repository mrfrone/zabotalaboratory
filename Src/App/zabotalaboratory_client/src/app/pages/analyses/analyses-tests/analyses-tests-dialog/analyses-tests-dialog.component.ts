import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {AnalysesTestsApiClient} from "../../../../core/apiClient/analyses/analyses-tests.api-client";
import {LaboratoryAnalysesTests} from "../../../../shared/models/analyses/laboratory-analyses-tests";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AnalysesTypes} from "../../../../shared/models/analyses/analyses-types";
import {UpdateAnalysesTestForm} from "../../../../shared/forms/analyses-tests/update-analyses-test.form";
import {DefaultSuccessMessages} from "../../../../shared/consts/defaultSuccessMessages";
import {MessageService} from "../../../../core/services/message.service";
import {UpdateAnalysesTestValidForm} from "../../../../shared/forms/analyses-tests/update-analyses-test-valid.form";
import {ZabotaResult} from "../../../../shared/models/zabota-result/zabota-result";
import {AnalysesTypesApiClient} from "../../../../core/apiClient/analyses/analyses-types.api-client";

@Component({
  selector: 'app-analyses-tests-dialog',
  templateUrl: './analyses-tests-dialog.component.html',
  styleUrls: ['./analyses-tests-dialog.component.scss']
})
export class AnalysesTestsDialogComponent implements OnInit {
  @Output() updateEvent = new EventEmitter();

  public testForm: FormGroup = new FormGroup({
    "testName": new FormControl("", Validators.required),
    "test1C": new FormControl("", [
      Validators.pattern("^[0-9]*$"),
      Validators.required
    ]),
    "testType": new FormControl("", Validators.required)
  });

  public isProgress: boolean = true;

  public test: LaboratoryAnalysesTests;
  public types: AnalysesTypes[];

  constructor(@Inject(MAT_DIALOG_DATA) public id: number,
              private readonly _analysesTests: AnalysesTestsApiClient,
              private readonly _analysesTypes: AnalysesTypesApiClient,
              private readonly _messages: MessageService) {}

  ngOnInit(): void {
    this._analysesTypes.getAnalysesTypesWithTests().subscribe(res => {
      this.types = res.result
    });

    this.updateData();
  }

  public onFormSubmit(): void {
    this.isProgress = true;

    const form: UpdateAnalysesTestForm = {
      id: this.test.id,
      name: this.testForm.controls['testName'].value,
      number1C: this.testForm.controls['test1C'].value,
      analysesTypesId: this.testForm.controls['testType'].value
    };

    this._analysesTests.updateAnalysesTest(form).subscribe(res => {
      this.afterUpdateTest(res, DefaultSuccessMessages.onUpdateTest);
    });
  }

  public onValidButton(): void {
    this.isProgress = true;

    const form: UpdateAnalysesTestValidForm = {
      id: this.test.id,
      isValid: !this.test.isValid
    }

    this._analysesTests.updateTestValidation(form).subscribe(res => {
      this.afterUpdateTest(res, DefaultSuccessMessages.onUpdateTestValid);
    });
  }

  private afterUpdateTest(res: ZabotaResult<any>, message: string): void {
    this._messages.showResult(res, message);
    this.updateData();
    this.updateEvent.emit();
  }

  private updateData(): void {
    this._analysesTests.getAnalysesTest(this.id).subscribe(res => {
      this.test = res.result;

      this.testForm.controls['testName'].setValue(res.result.name);
      this.testForm.controls['test1C'].setValue(res.result.number1C);
      this.testForm.controls['testType'].setValue(res.result.analysesTypesId);

      this.isProgress = false;
    });
  }
}
