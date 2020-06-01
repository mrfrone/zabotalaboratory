import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {SubRoles} from "../../../shared/models/users/sub-roles";
import {MessageService} from "../../../core/services/message.service";
import {MatDialog} from "@angular/material/dialog";
import {IdentitiesRolesApiClient} from "../../../core/apiClient/users/identities-roles.api-client";
import {AnalysesTypesDialogComponent} from "../../analyses/analyses-types/analyses-types-dialog/analyses-types-dialog.component";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AddNewSubRoleForm} from "../../../shared/forms/sub-roles/add-new-sub-role.form";
import {SubRolesSettingsDialogComponent} from "./sub-roles-settings-dialog/sub-roles-settings-dialog.component";

@Component({
  selector: 'app-sub-roles-settings',
  templateUrl: './sub-roles-settings.component.html',
  styleUrls: ['./sub-roles-settings.component.scss']
})
export class SubRolesSettingsComponent implements OnInit {

  public subRolesForm: FormGroup = new FormGroup({
    "subRoleName": new FormControl("", Validators.required)
  });

  public mainWindowIsProgress: boolean = true;
  public subRoles: SubRoles[];

  constructor(private readonly _roles: IdentitiesRolesApiClient,
              private readonly _messages: MessageService,
              private readonly _dialog: MatDialog) { }

  ngOnInit(): void {
    this.updateData();
  }

  public onTableElementClick(id: number): void {
    const dialog = this._dialog.open(SubRolesSettingsDialogComponent, {
      data: id
    });

    dialog.componentInstance.updateEvent.subscribe(() => {
      this.updateData();
    });
  }

  public onFormSubmit(): void {
    this.mainWindowIsProgress = true;

    const form: AddNewSubRoleForm = {
      name: this.subRolesForm.controls['subRoleName'].value
    };

    this._roles.addSubRole(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onNewSubRoleAdded);
      this.subRolesForm.reset();
      this.updateData();
    });
  }

  private updateData(): void {
    this._roles.getSubRoles()
      .subscribe(res => {
        this.subRoles = res.result
        this.mainWindowIsProgress = false;
      });
  }
}
