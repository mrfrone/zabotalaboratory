import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {LaboratoryAnalysesApiClient} from "../../../../core/apiClient/analyses/laboratory-analyses.api-client";
import {LaboratoryAnalyses} from "../../../../shared/models/analyses/laboratory-analyses";

@Component({
  selector: 'app-analyses-dialog',
  templateUrl: './analyses-dialog.component.html',
  styleUrls: ['./analyses-dialog.component.scss']
})
export class AnalysesDialogComponent implements OnInit {

  public isProgress: boolean = true;
  public laboratoryAnalyse: LaboratoryAnalyses;

  constructor(@Inject(MAT_DIALOG_DATA) public id: number,
              private readonly _analyses: LaboratoryAnalysesApiClient) { }

  ngOnInit(): void {
    this._analyses.getLaboratoryAnalyseById(this.id).subscribe(res => {
      this.laboratoryAnalyse = res.result

      this.isProgress = false;
    });
  }

  public downloadResult(id: number): void {

  }
}
