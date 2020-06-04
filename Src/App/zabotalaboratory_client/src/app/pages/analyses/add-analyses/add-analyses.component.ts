import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AnalysesTypesAddForm} from "../../../shared/models/analyses/add-form/analyses-types.add-form";
import {AnalysesTypesApiClient} from "../../../core/apiClient/analyses/analyses-types.api-client";
import {Clinic} from "../../../shared/models/analyses/clinic";
import {LaboratoryAnalysesApiClient} from "../../../core/apiClient/analyses/laboratory-analyses.api-client";
import {ClinicsApiClient} from "../../../core/apiClient/analyses/clinics.api-client";

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
              private readonly _clinics: ClinicsApiClient) { }

  ngOnInit(): void {
    this._analysesTypes.getAnalysesTypesWithTestsToAddForm().subscribe(res => {
      this.types = res.result
    });

    this._clinics.getOnlyValidClinics().subscribe(res => {
      this.clinics = res.result
      this.mainTableIsProgress = false;
    });


  }

  public onFormSubmit(): void {
    console.log(this.types);
  }

}
