import { Component, OnInit } from '@angular/core';
import {AnalysesTypes} from "../../../shared/models/analyses/analyses-types";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MessageService} from "../../../core/services/message.service";
import {MatDialog} from "@angular/material/dialog";
import {AnalysesTypesDialogComponent} from "./analyses-types-dialog/analyses-types-dialog.component";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AddNewAnalysesTypeForm} from "../../../shared/forms/analyses-types/add-new-analyses-type.form";
import {AnalysesTypesApiClient} from "../../../core/apiClient/analyses/analyses-types.api-client";
import {UpdateAnalysesTypesNumberInOrderForm} from "../../../shared/forms/analyses-types/update-analyses-types-number-in-order.form";

@Component({
  selector: 'app-analyses-types',
  templateUrl: './analyses-types.component.html',
  styleUrls: ['./analyses-types.component.scss']
})
export class AnalysesTypesComponent implements OnInit {

  public typesForm: FormGroup = new FormGroup({
    "typeName": new FormControl("", Validators.required),
    "typeExcelName": new FormControl("", Validators.required),
    "typePDFName": new FormControl("", Validators.required),
    "type1C": new FormControl("", [
      Validators.pattern("^[0-9]*$"),
      Validators.required
    ]),
    "typeBioMaterial": new FormControl("", Validators.required)
  });

  public mainWindowIsProgress: boolean = true;
  public types: AnalysesTypes[];

  constructor(private readonly _analysesTypes: AnalysesTypesApiClient,
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

    const form: AddNewAnalysesTypeForm = {
      name: this.typesForm.controls['typeName'].value,
      excelName: this.typesForm.controls['typeExcelName'].value,
      pdfName: this.typesForm.controls['typePDFName'].value,
      number1C: this.typesForm.controls['type1C'].value,
      bioMaterial: this.typesForm.controls['typeBioMaterial'].value
    };

    this._analysesTypes.addNewAnalysesType(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onNewTypeAdded);
      this.typesForm.reset();
      this.updateData();
    });
  }

  public changeNumberInOrder(number: number, isUp: boolean){
    const form: UpdateAnalysesTypesNumberInOrderForm = {
      numberInOrder: number,
      isUp: isUp
    };

    this._analysesTypes.updateTypeNumberInOrder(form).subscribe(() => {
      this.updateData()
    });
  }

  private updateData(): void {
    this._analysesTypes.getAnalysesTypesWithoutTests()
      .subscribe(res => {
        this.types = res.result
        this.mainWindowIsProgress = false;
      });
  }
}
