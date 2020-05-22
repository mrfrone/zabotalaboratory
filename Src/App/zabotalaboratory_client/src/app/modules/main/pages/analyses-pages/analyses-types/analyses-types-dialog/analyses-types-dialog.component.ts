import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {AnalysesApiClient} from "../../../../../../core/apiClient/analyses.api-client";
import {MessageService} from "../../../../../../core/services/message.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {LaboratoryAnalysesTests} from "../../../../../../shared/models/analyses/laboratory-analyses-tests";
import {AnalysesTypes} from "../../../../../../shared/models/analyses/analyses-types";
import {ZabotaResult} from "../../../../../../shared/models/zabota-result/zabota-result";
import {DefaultSuccessMessages} from "../../../../../../shared/consts/defaultSuccessMessages";

@Component({
  selector: 'app-analyses-types-dialog',
  templateUrl: './analyses-types-dialog.component.html',
  styleUrls: ['./analyses-types-dialog.component.scss']
})
export class AnalysesTypesDialogComponent implements OnInit {
  @Output() updateEvent = new EventEmitter();

  public typeForm: FormGroup = new FormGroup({
    "typeName": new FormControl("", Validators.required),
    "type1C": new FormControl("", [
      Validators.pattern("^[0-9]*$"),
      Validators.required
    ])
  });

  public isProgress: boolean = true;
  public type: AnalysesTypes;

  constructor(@Inject(MAT_DIALOG_DATA) public id: number,
              private readonly _analyses: AnalysesApiClient,
              private readonly _messages: MessageService) { }

  ngOnInit(): void {
    this.updateData();
  }

  public onFormSubmit(): void {}

  public onValidButton(): void {}

  private afterUpdateType(res: ZabotaResult<any>, message: string): void {
    this._messages.showResult(res, message);
    this.updateData();
    this.updateEvent.emit();
  }

  private updateData(): void {
    this._analyses.getAnalysesType(this.id).subscribe(res => {
      this.type = res.result;

      this.typeForm.controls['typeName'].setValue(res.result.name);
      this.typeForm.controls['type1C'].setValue(res.result.number1C);

      this.isProgress = false;
    });
  }
}
