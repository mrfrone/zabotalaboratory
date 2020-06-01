import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {SubRoles} from "../../../../shared/models/users/sub-roles";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {MessageService} from "../../../../core/services/message.service";
import {IdentitiesRolesApiClient} from "../../../../core/apiClient/users/identities-roles.api-client";
import {ZabotaResult} from "../../../../shared/models/zabota-result/zabota-result";
import {DefaultSuccessMessages} from "../../../../shared/consts/defaultSuccessMessages";
import {UpdateSubRoleForm} from "../../../../shared/forms/sub-roles/update-sub-role.form";
import {UpdateSubRoleValidForm} from "../../../../shared/forms/sub-roles/update-sub-role-valid.form";

@Component({
  selector: 'app-sub-roles-settings-dialog',
  templateUrl: './sub-roles-settings-dialog.component.html',
  styleUrls: ['./sub-roles-settings-dialog.component.scss']
})
export class SubRolesSettingsDialogComponent implements OnInit {

  @Output() updateEvent = new EventEmitter();

  public subRolesForm: FormGroup = new FormGroup({
    "subRoleName": new FormControl("", Validators.required)
  });

  public isProgress: boolean = true;
  public subRole: SubRoles;

  constructor(@Inject(MAT_DIALOG_DATA) public id: number,
              private readonly _roles: IdentitiesRolesApiClient,
              private readonly _messages: MessageService) { }

  ngOnInit(): void {
    this.updateData();
  }

  public onFormSubmit(): void {
    this.isProgress = true;

    const form: UpdateSubRoleForm = {
      id: this.subRole.id,
      name: this.subRolesForm.controls['subRoleName'].value
    };

    this._roles.updateSubRole(form).subscribe(res => {
      this.afterUpdateType(res, DefaultSuccessMessages.onUpdateSubRole);
    });
  }

  public onValidButton(): void {
    this.isProgress = true;

    const form: UpdateSubRoleValidForm = {
      id: this.subRole.id,
      isValid: !this.subRole.isValid
    }

    this._roles.updateSubRoleValidation(form).subscribe(res => {
      this.afterUpdateType(res, DefaultSuccessMessages.onUpdateSubRoleValid);
    });
  }

  private afterUpdateType(res: ZabotaResult<any>, message: string): void {
    this._messages.showResult(res, message);
    this.updateData();
    this.updateEvent.emit();
  }

  private updateData(): void {
    this._roles.getSubRoleById(this.id).subscribe(res => {
      this.subRole = res.result;

      this.subRolesForm.controls['subRoleName'].setValue(res.result.name);

      this.isProgress = false;
    });
  }
}
