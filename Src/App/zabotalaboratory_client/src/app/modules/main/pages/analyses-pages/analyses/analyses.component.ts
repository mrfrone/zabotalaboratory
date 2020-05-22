import { Component, OnInit } from '@angular/core';
import {LaboratoryAnalyses} from "../../../../../shared/models/analyses/laboratory-analyses";
import {AnalysesApiClient} from "../../../../../core/apiClient/analyses.api-client";

@Component({
  selector: 'app-main',
  templateUrl: './analyses.component.html',
  styleUrls: ['./analyses.component.scss']
})
export class AnalysesComponent implements OnInit {

  public mainTableIsProgress: boolean = true;
  public dataSource: LaboratoryAnalyses[];

  constructor(private readonly _analyses: AnalysesApiClient) { }

  ngOnInit(): void {
    this.Update();
  }

  public onNameSearchKeyUp(): void{

  }

  public onTableElementClick(id: number): void{
    console.log(id);
  }

  private Update(): void{
    this._analyses.getLaboratoryAnalyses()
      .subscribe(res =>
      {
        this.dataSource = res.result;
        this.mainTableIsProgress = false;
      });
  }
}

