import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {IdentitiesSettingsApiClient} from "../../../core/apiClient/users/identities-settings.api-client";
import {Identity} from "../../../shared/models/users/identity";
import {IdentitiesRolesApiClient} from "../../../core/apiClient/users/identities-roles.api-client";
import {SubRoles} from "../../../shared/models/users/sub-roles";
import {Roles} from "../../../shared/models/users/roles";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AddNewIdentityForm} from "../../../shared/forms/identities/add-new-identity.form";
import {MessageService} from "../../../core/services/message.service";
import {AnalysesTestsDialogComponent} from "../../analyses/analyses-tests/analyses-tests-dialog/analyses-tests-dialog.component";
import {MatDialog} from "@angular/material/dialog";
import {IdentitiesSettingsDialogComponent} from "./identities-settings-dialog/identities-settings-dialog.component";

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
    "identitiesSubRole": new FormControl()
  });

  public mainWindowIsProgress: boolean = true;
  public identities: Identity[];
  public roles: Roles[];
  public subRoles: SubRoles[];

  constructor(private readonly _identities: IdentitiesSettingsApiClient,
              private readonly _roles: IdentitiesRolesApiClient,
              private readonly _messages: MessageService,
              private readonly _dialog: MatDialog) { }

  ngOnInit(): void {
    this._roles.getRoles().subscribe(res => {
      this.roles = res.result;
    });
    this._roles.getOnlyValidSubRoles().subscribe(res => {
      this.subRoles = res.result;
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

    const form: AddNewIdentityForm = {
      login: this.identitiesForm.controls['identitiesLogin'].value,
      password: this.identitiesForm.controls['identitiesPassword'].value,
      roleId: this.identitiesForm.controls['identitiesRole'].value,
      subRoleId: this.identitiesForm.controls['identitiesSubRole'].value
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

  private updateData(): void{
    this._identities.getIdentities()
      .subscribe(res => {
        this.identities = res.result
        this.mainWindowIsProgress = false;
      });
  }
}
