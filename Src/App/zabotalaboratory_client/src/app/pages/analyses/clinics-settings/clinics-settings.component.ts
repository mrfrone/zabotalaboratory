import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MessageService} from "../../../core/services/message.service";
import {MatDialog} from "@angular/material/dialog";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AddClinicRoleForm} from "../../../shared/forms/clinics/add-clinic-role.form";
import {ClinicsSettingsDialogComponent} from "./clinics-settings-dialog/clinics-settings-dialog.component";
import {ClinicsApiClient} from "../../../core/apiClient/analyses/clinics.api-client";
import {Clinic} from "../../../shared/models/analyses/clinic";

@Component({
  selector: 'app-clinics-settings',
  templateUrl: './clinics-settings.component.html',
  styleUrls: ['./clinics-settings.component.scss']
})
export class ClinicsSettingsComponent implements OnInit {

  public clinicsForm: FormGroup = new FormGroup({
    "clinicName": new FormControl("", Validators.required)
  });

  public mainWindowIsProgress: boolean = true;
  public clinics: Clinic[];

  constructor(private readonly _clinics: ClinicsApiClient,
              private readonly _messages: MessageService,
              private readonly _dialog: MatDialog) { }

  ngOnInit(): void {
    this.updateData();
  }

  public onTableElementClick(id: number): void {
    const dialog = this._dialog.open(ClinicsSettingsDialogComponent, {
      data: id
    });

    dialog.componentInstance.updateEvent.subscribe(() => {
      this.updateData();
    });
  }

  public onFormSubmit(): void {
    this.mainWindowIsProgress = true;

    const form: AddClinicRoleForm = {
      name: this.clinicsForm.controls['clinicName'].value
    };

    this._clinics.addClinic(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onClinicAdded);
      this.clinicsForm.reset();
      this.updateData();
    });
  }

  private updateData(): void {
    this._clinics.getClinics()
      .subscribe(res => {
        this.clinics = res.result
        this.mainWindowIsProgress = false;
      });
  }
}
