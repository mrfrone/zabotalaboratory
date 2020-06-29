import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {LaboratoryAnalyses} from "../../../../shared/models/analyses/laboratory-analyses";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {LaboratoryAnalysesApiClient} from "../../../../core/apiClient/analyses/laboratory-analyses.api-client";
import {MessageService} from "../../../../core/services/message.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {UpdateLaboratoryAnalysesValidForm} from "../../../../shared/forms/laboratory-analyses/update-laboratory-analyses-valid.form";
import {DefaultSuccessMessages} from "../../../../shared/consts/defaultSuccessMessages";
import {UpdateMedicalRecordForm} from "../../../../shared/forms/medical-records/update-medical-record.form";
import {DownloadFileForm} from "../../../../shared/forms/common/download-file.form";

@Component({
  selector: 'app-analyses-medical-record-dialog',
  templateUrl: './analyses-medical-record-dialog.component.html',
  styleUrls: ['./analyses-medical-record-dialog.component.scss']
})
export class AnalysesMedicalRecordDialogComponent implements OnInit {
  @Output() updateEvent = new EventEmitter();

  public reportButtonDisabled: boolean = false;
  public isProgress: boolean = true;
  public laboratoryAnalyse: LaboratoryAnalyses;

  public medicalRecordForm: FormGroup = new FormGroup({
    "insuranceName": new FormControl("", Validators.required),
    "policyNumber": new FormControl("", Validators.required),
    "snilsNumber": new FormControl("", Validators.required),
    "privilegeCode": new FormControl("", Validators.required),
    "permanentAddress": new FormControl("", Validators.required),
    "actualAddress": new FormControl("", Validators.required),
    "phoneNumber": new FormControl("", Validators.required),
    "preferentialProvision": new FormControl("", Validators.required),
    "disability": new FormControl("", Validators.required),
    "placeOfWork": new FormControl("", Validators.required),
    "profession": new FormControl("", Validators.required),
    "position": new FormControl("", Validators.required),
    "dependent": new FormControl("", Validators.required)
  });

  constructor(@Inject(MAT_DIALOG_DATA) public id: number,
              private readonly _analyses: LaboratoryAnalysesApiClient,
              private readonly _message: MessageService) { }

  ngOnInit(): void {
    this.updateData();
  }

  public downloadMedicalRecord(): void {
    this.reportButtonDisabled = true;

    const form: DownloadFileForm = {
      id: this.id
    };

    this._analyses.getMedicalRecordReport(form).subscribe(res => {
      window.open(window.URL.createObjectURL(res), "_blank");
      this.reportButtonDisabled = false;
    });
  }

  public updateMedicalRecord(): void {
    const form: UpdateMedicalRecordForm = {
      id: this.id,
      insuranceName: this.medicalRecordForm.controls['insuranceName'].value,
      policyNumber: this.medicalRecordForm.controls['policyNumber'].value,
      snilsNumber: this.medicalRecordForm.controls['snilsNumber'].value,
      privilegeCode: this.medicalRecordForm.controls['privilegeCode'].value,
      permanentAddress: this.medicalRecordForm.controls['permanentAddress'].value,
      actualAddress: this.medicalRecordForm.controls['actualAddress'].value,
      phoneNumber: this.medicalRecordForm.controls['phoneNumber'].value,
      preferentialProvision: this.medicalRecordForm.controls['preferentialProvision'].value,
      disability: this.medicalRecordForm.controls['disability'].value,
      placeOfWork: this.medicalRecordForm.controls['placeOfWork'].value,
      profession: this.medicalRecordForm.controls['profession'].value,
      position: this.medicalRecordForm.controls['position'].value,
      dependent: this.medicalRecordForm.controls['dependent'].value
    };

    this._analyses.updateMedicalRecord(form).subscribe(res => {
      this._message.showResult(res, DefaultSuccessMessages.onUpdateMedicalRecord)
      this.updateData();
    });
  }

  public onValidButton(): void {
    const form: UpdateLaboratoryAnalysesValidForm = {
      id: this.id,
      isValid: !this.laboratoryAnalyse.isValid
    };

    this._analyses.updateLaboratoryAnalyseValid(form).subscribe(res => {
      this._message.showResult(res, DefaultSuccessMessages.onUpdateLaboratoryAnalyseValid);
      this.updateEvent.emit();
      this.updateData();
    })
  }

  public updateData(): void{
    this._analyses.getLaboratoryAnalysesWithMedicalRecord(this.id).subscribe(res => {
      this.laboratoryAnalyse = res.result;

      this.medicalRecordForm.controls['insuranceName'].setValue(res.result.medicalRecord.insuranceName);
      this.medicalRecordForm.controls['policyNumber'].setValue(res.result.medicalRecord.policyNumber);
      this.medicalRecordForm.controls['snilsNumber'].setValue(res.result.medicalRecord.snilsNumber);
      this.medicalRecordForm.controls['privilegeCode'].setValue(res.result.medicalRecord.privilegeCode);
      this.medicalRecordForm.controls['permanentAddress'].setValue(res.result.medicalRecord.permanentAddress);
      this.medicalRecordForm.controls['actualAddress'].setValue(res.result.medicalRecord.actualAddress);
      this.medicalRecordForm.controls['phoneNumber'].setValue(res.result.medicalRecord.phoneNumber);
      this.medicalRecordForm.controls['preferentialProvision'].setValue(res.result.medicalRecord.preferentialProvision);
      this.medicalRecordForm.controls['disability'].setValue(res.result.medicalRecord.disability);
      this.medicalRecordForm.controls['placeOfWork'].setValue(res.result.medicalRecord.placeOfWork);
      this.medicalRecordForm.controls['profession'].setValue(res.result.medicalRecord.profession);
      this.medicalRecordForm.controls['position'].setValue(res.result.medicalRecord.position);
      this.medicalRecordForm.controls['dependent'].setValue(res.result.medicalRecord.dependent);

      this.isProgress = false;
    });
  }

}
