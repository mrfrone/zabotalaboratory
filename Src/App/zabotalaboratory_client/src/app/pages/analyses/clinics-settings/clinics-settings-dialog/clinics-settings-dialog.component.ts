import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {MessageService} from "../../../../core/services/message.service";
import {ZabotaResult} from "../../../../shared/models/zabota-result/zabota-result";
import {DefaultSuccessMessages} from "../../../../shared/consts/defaultSuccessMessages";
import {UpdateClinicForm} from "../../../../shared/forms/clinics/update-clinic.form";
import {UpdateClinicValidForm} from "../../../../shared/forms/clinics/update-clinic-valid.form";
import {ClinicsApiClient} from "../../../../core/apiClient/analyses/clinics.api-client";
import {Clinic} from "../../../../shared/models/analyses/clinic";

@Component({
  selector: 'app-clinics-settings-dialog',
  templateUrl: './clinics-settings-dialog.component.html',
  styleUrls: ['./clinics-settings-dialog.component.scss']
})
export class ClinicsSettingsDialogComponent implements OnInit {

  @Output() updateEvent = new EventEmitter();

  public clinicsForm: FormGroup = new FormGroup({
    "clinicName": new FormControl("", Validators.required)
  });

  public isProgress: boolean = true;
  public clinic: Clinic;

  constructor(@Inject(MAT_DIALOG_DATA) public id: number,
              private readonly _clinics: ClinicsApiClient,
              private readonly _messages: MessageService) { }

  ngOnInit(): void {
    this.updateData();
  }

  public onFormSubmit(): void {
    this.isProgress = true;

    const form: UpdateClinicForm = {
      id: this.clinic.id,
      name: this.clinicsForm.controls['clinicName'].value
    };

    this._clinics.updateClinic(form).subscribe(res => {
      this.afterUpdateType(res, DefaultSuccessMessages.onUpdateClinic);
    });
  }

  public onValidButton(): void {
    this.isProgress = true;

    const form: UpdateClinicValidForm = {
      id: this.clinic.id,
      isValid: !this.clinic.isValid
    }

    this._clinics.updateClinicValidation(form).subscribe(res => {
      this.afterUpdateType(res, DefaultSuccessMessages.onUpdateClinicValid);
    });
  }

  private afterUpdateType(res: ZabotaResult<any>, message: string): void {
    this._messages.showResult(res, message);
    this.updateData();
    this.updateEvent.emit();
  }

  private updateData(): void {
    this._clinics.getClinicById(this.id).subscribe(res => {
      this.clinic = res.result;

      this.clinicsForm.controls['clinicName'].setValue(res.result.name);

      this.isProgress = false;
    });
  }
}
