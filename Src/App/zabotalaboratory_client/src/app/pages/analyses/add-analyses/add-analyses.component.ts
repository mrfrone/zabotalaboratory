import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AnalysesTypesAddForm} from "../../../shared/models/analyses/add-form/analyses-types.add-form";
import {AnalysesTypesApiClient} from "../../../core/apiClient/analyses/analyses-types.api-client";
import {Clinic} from "../../../shared/models/analyses/clinic";
import {LaboratoryAnalysesApiClient} from "../../../core/apiClient/analyses/laboratory-analyses.api-client";
import {ClinicsApiClient} from "../../../core/apiClient/analyses/clinics.api-client";
import {AddLaboratoryAnalysesForm} from "../../../shared/forms/laboratory-analyses/add-laboratory-analyses.form";
import {AddAnalysesResultForm} from "../../../shared/forms/laboratory-analyses/add-analyses-result.form";
import {AddTalonsForm} from "../../../shared/forms/laboratory-analyses/add-talons.form";
import {MessageService} from "../../../core/services/message.service";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {AuthCheckerService} from "../../../core/services/auth-checker.service";

@Component({
  selector: 'app-add-analyses',
  templateUrl: './add-analyses.component.html',
  styleUrls: ['./add-analyses.component.scss']
})
export class AddAnalysesComponent implements OnInit {

  public analysesForm: FormGroup = new FormGroup({
    "FirstName": new FormControl("", Validators.required),
    "LastName": new FormControl("", Validators.required),
    "PatronymicName": new FormControl("", Validators.required),
    "DateOfBirth": new FormControl("", Validators.required),
    "Clinic": new FormControl("", Validators.required),
    "Doctor": new FormControl("", Validators.required)
  });

  public types: AnalysesTypesAddForm[];
  public clinics: Clinic[];

  public mainTableIsProgress: boolean = true;

  constructor(private readonly _analysesTypes: AnalysesTypesApiClient,
              private readonly _analyses: LaboratoryAnalysesApiClient,
              private readonly _clinics: ClinicsApiClient,
              private readonly _message: MessageService,
              private readonly _auth: AuthCheckerService) {}

  ngOnInit(): void {
    this.updateData();
  }

  public onFormSubmit(): void {
    this.mainTableIsProgress = true;

    let talons: AddTalonsForm[] = [];

    this.types.forEach(type => {
      let results: AddAnalysesResultForm[] = [];

      type.laboratoryAnalysesTests.forEach(test => {
        results.push({laboratoryAnalysesTestsId: test.id, isNeeded: test.isNeeded})
      });

      talons.push({analysesTypeId: type.id, analysesResult: results, isNeeded: type.isNeeded});
    });

    let form: AddLaboratoryAnalysesForm = {
      firstName: this.analysesForm.controls['FirstName'].value,
      lastName: this.analysesForm.controls['LastName'].value,
      patronymicName: this.analysesForm.controls['PatronymicName'].value,
      dateOfBirth: this.analysesForm.controls['DateOfBirth'].value,
      clinicId: this.analysesForm.controls['Clinic'].value,
      doctor: this.analysesForm.controls['Doctor'].value,
      talons: talons
    };

    this._analyses.addLaboratoryAnalyse(form).subscribe(res => {
      this._message.showResult(res, DefaultSuccessMessages.onLaboratoryAnalyseAdded);
      this.analysesForm.reset();

      this.updateData();
    });
  }

  public onTypeCheckBoxChanged(id: number): void {
    if (this.types.find(u => u.id == id).isNeeded === true) {
      this.types.filter(t => t.id == id).forEach(function (value) {
        value.laboratoryAnalysesTests.forEach(function (value) {
          value.isNeeded = true;
        });
      });
    } else {
      this.types.filter(t => t.id == id).forEach(function (value) {
        value.laboratoryAnalysesTests.forEach(function (value) {
          value.isNeeded = false;
        });
      });
    }
  }

  public onTestCheckBoxChanged(id: number): void {
    this.types.filter(t => t.id == id).forEach(function (value) {
      let allTrueOrFalseFlag = true;
      let breakMass: boolean = true;

      value.laboratoryAnalysesTests.forEach(function (value) {
        if (breakMass) {
          if (value.isNeeded == false) {
            allTrueOrFalseFlag = false;
          } else {
            allTrueOrFalseFlag = true;
            breakMass = false;
          }
        }
      });
      value.isNeeded = allTrueOrFalseFlag;
    });
  }

  private updateData(): void {
    this._analysesTypes.getAnalysesTypesWithTestsToAddForm().subscribe(res => {
      this.types = res.result
      this.mainTableIsProgress = false;
    });

    this._clinics.getClinicsForCurrentUser().subscribe(res => {
      this.clinics = res.result;
    });
  }
}
