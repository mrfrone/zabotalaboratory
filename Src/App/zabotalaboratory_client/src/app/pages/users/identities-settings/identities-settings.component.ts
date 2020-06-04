import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {IdentitiesSettingsApiClient} from "../../../core/apiClient/users/identities-settings.api-client";
import {Identity} from "../../../shared/models/users/identity";
import {IdentitiesRolesApiClient} from "../../../core/apiClient/users/identities-roles.api-client";
import {Roles} from "../../../shared/models/users/roles";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AddIdentityForm} from "../../../shared/forms/identities/add-identity.form";
import {MessageService} from "../../../core/services/message.service";
import {MatDialog} from "@angular/material/dialog";
import {IdentitiesSettingsDialogComponent} from "./identities-settings-dialog/identities-settings-dialog.component";
import {ClinicsApiClient} from "../../../core/apiClient/analyses/clinics.api-client";
import {Clinic} from "../../../shared/models/analyses/clinic";
import {ClinicNameFilter} from "../../../core/filters/clinic-name.filter";

@Component({
  selector: 'app-users-settings',
  templateUrl: './identities-settings.component.html',
  styleUrls: ['./identities-settings.component.scss']
})
export class IdentitiesSettingsComponent implements OnInit {

  public identitiesForm: FormGroup = new FormGroup({

    "identitiesLogin": new FormControl("", Validators.required),
    "identitiesPassword": new FormControl("",Validators.required),
    "identitiesPasswordConfirm": new FormControl("", Validators.required),
    "identitiesRole": new FormControl("", Validators.required),
    "identitiesClinicId": new FormControl()
  });

  public mainWindowIsProgress: boolean = true;
  public identities: Identity[];
  public roles: Roles[];
  public clinics: Clinic[];

  constructor(private readonly _identities: IdentitiesSettingsApiClient,
              private readonly _roles: IdentitiesRolesApiClient,
              private readonly _clinics: ClinicsApiClient,
              private readonly _messages: MessageService,
              private readonly _dialog: MatDialog) { }

  ngOnInit(): void {
    this._roles.getRoles().subscribe(res => {
      this.roles = res.result;
    });
    this._clinics.getOnlyValidClinics().subscribe(res => {
      this.clinics = res.result;
    });

    this.updateData();
  }

  public onFormSubmit(): void {
    this.mainWindowIsProgress = true;

    if(this.identitiesForm.controls['identitiesPassword'].value !== this.identitiesForm.controls['identitiesPasswordConfirm'].value)
    {
      this._messages.showMessage("Пароли не совпадают!");
      this.mainWindowIsProgress = false;
      return
    }

    let clinicName: string = ClinicNameFilter.getName(this.identitiesForm.controls['identitiesClinicId'].value, this.clinics);

    const form: AddIdentityForm = {
      login: this.identitiesForm.controls['identitiesLogin'].value,
      password: this.identitiesForm.controls['identitiesPassword'].value,
      roleId: this.identitiesForm.controls['identitiesRole'].value,
      clinicId: this.identitiesForm.controls['identitiesClinicId'].value,
      clinicName: clinicName
    };

    this._identities.addIdentity(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onNewIdentityAdded);
      this.identitiesForm.reset();
      this.updateData();
    });
  }

  public onTableElementClick(id: number): void {
    const dialog = this._dialog.open(IdentitiesSettingsDialogComponent, {
      data: id
    });

    dialog.componentInstance.updateEvent.subscribe(() => {
      this.updateData();
    });
  }

  private updateData(): void {
    this._identities.getIdentities()
      .subscribe(res => {
        this.identities = res.result
        this.mainWindowIsProgress = false;
      });
  }
}
