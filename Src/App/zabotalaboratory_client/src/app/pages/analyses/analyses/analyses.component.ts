import { Component, OnInit } from '@angular/core';
import {LaboratoryAnalyses} from "../../../shared/models/analyses/laboratory-analyses";
import {LaboratoryAnalysesApiClient} from "../../../core/apiClient/analyses/laboratory-analyses.api-client";
import {AnalysesDialogComponent} from "./analyses-dialog/analyses-dialog.component";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-main',
  templateUrl: './analyses.component.html',
  styleUrls: ['./analyses.component.scss']
})
export class AnalysesComponent implements OnInit {

  public mainTableIsProgress: boolean = true;
  public laboratoryAnalyses: LaboratoryAnalyses[];

  constructor(private readonly _analyses: LaboratoryAnalysesApiClient,
              private readonly _dialog: MatDialog) { }

  ngOnInit(): void {
    this.Update();
  }

  public onNameSearchKeyUp(): void{

  }

  public onTableElementClick(id: number): void{
    this._dialog.open(AnalysesDialogComponent, {
      data: id
    });
  }

  private Update(): void{
    this._analyses.getLaboratoryAnalyses()
      .subscribe(res =>
      {
        this.laboratoryAnalyses = res.result;
        this.mainTableIsProgress = false;
      });
  }
}

