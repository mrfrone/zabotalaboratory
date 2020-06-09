import { Component, OnInit } from '@angular/core';
import {AnalysesTypes} from "../../../shared/models/analyses/analyses-types";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AddNewAnalysesTestForm} from "../../../shared/forms/analyses-tests/add-new-analyses-test.form";
import {AnalysesTestsApiClient} from "../../../core/apiClient/analyses/analyses-tests.api-client";
import {MessageService} from "../../../core/services/message.service";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {MatDialog} from "@angular/material/dialog";
import {AnalysesTestsDialogComponent} from "./analyses-tests-dialog/analyses-tests-dialog.component";
import {AnalysesTypesApiClient} from "../../../core/apiClient/analyses/analyses-types.api-client";

@Component({
  selector: 'app-analyses-tests',
  templateUrl: './analyses-tests.component.html',
  styleUrls: ['./analyses-tests.component.scss']
})
export class AnalysesTestsComponent implements OnInit {

  public testsForm: FormGroup = new FormGroup({

    "testName": new FormControl("", Validators.required),
    "test1C": new FormControl("", [
      Validators.pattern("^[0-9]*$"),
      Validators.required
    ]),
    "testType": new FormControl("", Validators.required),
    "testUnits": new FormControl("", Validators.required),
    "testReferenceLimits": new FormControl("", Validators.required)
  });

  public mainWindowIsProgress: boolean = true;
  public types: AnalysesTypes[];

  constructor(private readonly _analysesTests: AnalysesTestsApiClient,
              private readonly _analysesTypes: AnalysesTypesApiClient,
              private readonly _messages: MessageService,
              private readonly _dialog: MatDialog) { }

  ngOnInit(): void {
    this.updateData();
  }

  public onTableElementClick(id: number): void {
    const dialog = this._dialog.open(AnalysesTestsDialogComponent, {
      data: id
    });

    dialog.componentInstance.updateEvent.subscribe(() => {
      this.updateData();
    });
  }

  public onFormSubmit(): void{
    this.mainWindowIsProgress = true;

    const form: AddNewAnalysesTestForm = {
      name: this.testsForm.controls['testName'].value,
      number1C: this.testsForm.controls['test1C'].value,
      analysesTypesId: this.testsForm.controls['testType'].value,
      units: this.testsForm.controls['testUnits'].value,
      referenceLimits: this.testsForm.controls['testReferenceLimits'].value
    };

    this._analysesTests.addNewAnalysesTest(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onNewTestAdded);
      this.testsForm.reset();
      this.updateData();
    });
  }

  private updateData(): void{
    this._analysesTypes.getAnalysesTypesWithTests()
      .subscribe(res => {
      this.types = res.result
      this.mainWindowIsProgress = false;
    });
  }
}
