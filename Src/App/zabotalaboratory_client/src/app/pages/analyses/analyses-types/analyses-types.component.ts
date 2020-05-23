import { Component, OnInit } from '@angular/core';
import {AnalysesTypes} from "../../../shared/models/analyses/analyses-types";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AnalysesApiClient} from "../../../core/apiClient/analyses.api-client";
import {MessageService} from "../../../core/services/message.service";
import {MatDialog} from "@angular/material/dialog";
import {AnalysesTypesDialogComponent} from "./analyses-types-dialog/analyses-types-dialog.component";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {NewAnalysesTypeForm} from "../../../shared/forms/analyses-types/new-analyses-type.form";

@Component({
  selector: 'app-analyses-types',
  templateUrl: './analyses-types.component.html',
  styleUrls: ['./analyses-types.component.scss']
})
export class AnalysesTypesComponent implements OnInit {

  public typesForm: FormGroup = new FormGroup({
    "typeName": new FormControl("", Validators.required),
    "type1C": new FormControl("", [
      Validators.pattern("^[0-9]*$"),
      Validators.required
    ])
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
    const dialog = this._dialog.open(AnalysesTypesDialogComponent, {
      data: id
    });

    dialog.componentInstance.updateEvent.subscribe(() => {
      this.updateData();
    });
  }

  public onFormSubmit(): void {
    this.mainWindowIsProgress = true;

    const form: NewAnalysesTypeForm = {
      name: this.typesForm.controls['typeName'].value,
      number1C: this.typesForm.controls['type1C'].value
    };

    this._analyses.addNewAnalysesType(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onNewTypeAdded);
      this.typesForm.reset();
      this.updateData();
    });
  }

  private updateData(): void {
    this._analyses.getAnalysesTypesWithoutTests()
      .subscribe(res => {
        this.types = res.result
        this.mainWindowIsProgress = false;
      });
  }
}
