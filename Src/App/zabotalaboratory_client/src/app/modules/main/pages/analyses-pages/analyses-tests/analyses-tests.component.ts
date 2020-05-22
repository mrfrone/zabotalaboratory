import { Component, OnInit } from '@angular/core';
import {AnalysesTypes} from "../../../../../shared/models/analyses/analyses-types";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {NewAnalysesTestForm} from "../../../../../shared/forms/Analyses/new-analyses-test.form";
import {AnalysesApiClient} from "../../../../../core/apiClient/analyses.api-client";
import {MessageService} from "../../../../../core/services/message.service";
import {DefaultSuccessMessages} from "../../../../../shared/consts/defaultSuccessMessages";
import {MatDialog} from "@angular/material/dialog";
import {AnalysesTestsDialogComponent} from "./analyses-tests-dialog/analyses-tests-dialog.component";

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
    "testType": new FormControl("", Validators.required)
  });

  public mainWindowIsProgress: boolean = true;
  public types: AnalysesTypes[];

  constructor(private readonly _analyses: AnalysesApiClient,
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

    const form: NewAnalysesTestForm = {
      name: this.testsForm.controls['testName'].value,
      number1C: this.testsForm.controls['test1C'].value,
      analysesTypesId: this.testsForm.controls['testType'].value
    };

    this._analyses.addNewAnalysesTest(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onNewTestAdded);
      this.testsForm.reset();
      this.updateData();
    });
  }

  private updateData(): void{
    this._analyses.getAnalysesTypes()
      .subscribe(res => {
      this.types = res.result
      this.mainWindowIsProgress = false;
    });
  }
}
