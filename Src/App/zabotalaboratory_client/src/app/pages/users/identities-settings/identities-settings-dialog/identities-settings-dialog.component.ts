import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {MessageService} from "../../../../core/services/message.service";
import {IdentitiesRolesApiClient} from "../../../../core/apiClient/users/identities-roles.api-client";
import {IdentitiesSettingsApiClient} from "../../../../core/apiClient/users/identities-settings.api-client";
import {Identity} from "../../../../shared/models/users/identity";
import {Roles} from "../../../../shared/models/users/roles";
import {DefaultSuccessMessages} from "../../../../shared/consts/defaultSuccessMessages";
import {UpdateIdentityForm} from "../../../../shared/forms/identities/update-identity.form";
import {ClinicsApiClient} from "../../../../core/apiClient/analyses/clinics.api-client";
import {Clinic} from "../../../../shared/models/analyses/clinic";
import { ClinicNameFilter } from 'src/app/core/filters/clinic-name.filter';

@Component({
  selector: 'app-identities-settings-dialog',
  templateUrl: './identities-settings-dialog.component.html',
  styleUrls: ['./identities-settings-dialog.component.scss']
})
export class IdentitiesSettingsDialogComponent implements OnInit {

  @Output() updateEvent = new EventEmitter();

  public identityForm: FormGroup = new FormGroup({

    "identitiesLogin": new FormControl("", Validators.required),
    "identitiesPassword": new FormControl({value: '', disabled: true}),
    "identitiesPasswordConfirm": new FormControl({value: '', disabled: true}),
    "changePasswordCheck": new FormControl(),
    "identitiesRole": new FormControl("", Validators.required),
    "identitiesClinic": new FormControl()
  });

  public isProgress: boolean = true;

  public identity: Identity;
  public roles: Roles[];
  public clinics: Clinic[];

  constructor(private readonly dialogRef: MatDialogRef<IdentitiesSettingsDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public id: number,
              private readonly _identities: IdentitiesSettingsApiClient,
              private readonly _roles: IdentitiesRolesApiClient,
              private readonly _clinics: ClinicsApiClient,
              private readonly _messages: MessageService) { }

  ngOnInit(): void {
    this._roles.getRoles().subscribe(res => {
      this.roles = res.result;
    });
    this._clinics.getOnlyValidClinics().subscribe(res => {
      this.clinics = res.result;
    });

    this.updateData();
  }

  public onCheckBoxChanged(): void {
    if(this.identityForm.controls['changePasswordCheck'].value)
    {
      this.identityForm.controls['identitiesPassword'].setValidators(Validators.required);
      this.identityForm.controls['identitiesPassword'].enable();
      this.identityForm.controls['identitiesPassword'].updateValueAndValidity();

      this.identityForm.controls['identitiesPasswordConfirm'].setValidators(Validators.required);
      this.identityForm.controls['identitiesPasswordConfirm'].enable();
      this.identityForm.controls['identitiesPasswordConfirm'].updateValueAndValidity();
    }
    else {
      this.identityForm.controls['identitiesPassword'].setValidators(null);
      this.identityForm.controls['identitiesPassword'].disable();
      this.identityForm.controls['identitiesPassword'].updateValueAndValidity();

      this.identityForm.controls['identitiesPasswordConfirm'].setValidators(null);
      this.identityForm.controls['identitiesPasswordConfirm'].disable();
      this.identityForm.controls['identitiesPasswordConfirm'].updateValueAndValidity();
    }
  }

  public onFormSubmit(): void {
    this.isProgress = true;

    if(this.identityForm.controls['changePasswordCheck'].value) {
      if (this.identityForm.controls['identitiesPassword'].value != this.identityForm.controls['identitiesPasswordConfirm'].value) {
        this._messages.showMessage('Пароли не совпадают!');
        this.isProgress = false;
        return
      }
    }

    let clinicName: string = ClinicNameFilter.getName(this.identityForm.controls['identitiesClinic'].value, this.clinics);

    const form: UpdateIdentityForm = {
      id: this.identity.id,
      login: this.identityForm.controls['identitiesLogin'].value,
      password: this.identityForm.controls['identitiesPassword'].value,
      changePassword: this.identityForm.controls['changePasswordCheck'].value,
      roleId: this.identityForm.controls['identitiesRole'].value,
      clinicId: this.identityForm.controls['identitiesClinic'].value,
      clinicName: clinicName
    };

    this._identities.updateIdentity(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onUpdateIdentity);
      this.identityForm.reset();
      this.onCheckBoxChanged();
      this.updateData();
      this.updateEvent.emit();
    });
  }

  public onDeleteButton(): void {
    this.isProgress = true;

    this._identities.deleteIdentity(this.identity.id).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onIdentityDeleted);
      this.updateEvent.emit();
      this.dialogRef.close();
    });
  }

  private updateData(): void {
    this._identities.getIdentity(this.id).subscribe(res => {
      this.identity = res.result;

      this.identityForm.controls['identitiesLogin'].setValue(res.result.login);
      this.identityForm.controls['identitiesRole'].setValue(res.result.role.id);
      this.identityForm.controls['changePasswordCheck'].setValue(false);
      this.identityForm.controls['identitiesClinic'].setValue(res.result.clinicId);

      this.isProgress = false;
    });
  }
}
