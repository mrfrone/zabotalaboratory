import { Component, OnInit } from '@angular/core';
import {LaboratoryAnalyses} from "../../../shared/models/analyses/laboratory-analyses";
import {LaboratoryAnalysesApiClient} from "../../../core/apiClient/analyses/laboratory-analyses.api-client";
import {AnalysesDialogComponent} from "./analyses-dialog/analyses-dialog.component";
import {MatDialog} from "@angular/material/dialog";
import {Pager} from "../../../shared/models/pager/pager";
import {SearchLaboratoryAnalysesForm} from "../../../shared/forms/laboratory-analyses/search-laboratory-analyses.form";
import {AnalysesMedicalRecordDialogComponent} from "./analyses-medical-record-dialog/analyses-medical-record-dialog.component";
import {AvailableRoleService} from "../../../core/services/available-role.service";
import {StaticRoles} from "../../../shared/consts/staticRoles";

@Component({
  selector: 'app-main',
  templateUrl: './analyses.component.html',
  styleUrls: ['./analyses.component.scss']
})
export class AnalysesComponent implements OnInit {

  public lastName: string = "";
  public firstName: string = "";
  public patronymicName: string = "";

  public isSearchingData: boolean = false;

  public mainTableIsProgress: boolean = true;
  public laboratoryAnalyses: Pager<LaboratoryAnalyses[]>;

  constructor(private readonly _analyses: LaboratoryAnalysesApiClient,
              private readonly _dialog: MatDialog,
              private readonly _availableRole: AvailableRoleService) { }

  ngOnInit(): void {
    this.updateData();
  }

  public onTableElementClick(id: number): void{
    this._dialog.open(AnalysesDialogComponent, {
      data: id
    });
  }

  public onMedicalRecordButtonClick(id: number): void{
    const dialog = this._dialog.open(AnalysesMedicalRecordDialogComponent,{
      data: id
    });

    dialog.componentInstance.updateEvent.subscribe(() => {
      this.updateData(this.laboratoryAnalyses.pageNumber);
    });
  }

  public onSearchButtonClick(): void {
    this.mainTableIsProgress = true;
    this.isSearchingData = true;
    this.updateData();
  }

  public resetSearching(): void {
    this.isSearchingData = false;

    this.lastName = "";
    this.firstName = "";
    this.patronymicName = "";

    this.updateData();
  }

  public updateData(page: number = 1): void {
    if(this.isSearchingData){
      const form: SearchLaboratoryAnalysesForm = {
        lastName: this.lastName,
        firstName: this.firstName,
        patronymicName: this.patronymicName,
        pickUpDate: null,
        page: page
      };

      console.log(form);
      console.log(this.lastName);
      this._analyses.getSearchLaboratoryAnalyses(form).subscribe(res => {
        this.laboratoryAnalyses = res.result;
        this.mainTableIsProgress = false;
      });
    }
    else {
      this._analyses.getLaboratoryAnalyses(page)
        .subscribe(res => {
          this.laboratoryAnalyses = res.result;
          this.mainTableIsProgress = false;
        });
    }
  }

  public admin: string = StaticRoles.admin;
  public laborant: string = StaticRoles.laborant;
  public clinic: string = StaticRoles.clinic;

  public isAvailable(roles: string[]): boolean {
    return this._availableRole.isAvailable(roles);
  }
}

