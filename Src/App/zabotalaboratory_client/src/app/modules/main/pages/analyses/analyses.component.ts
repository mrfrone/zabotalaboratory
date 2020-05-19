import { Component, OnInit } from '@angular/core';
import {AnalysesService} from "../../../../core/services/analyses.service";
import {LaboratoryAnalyses} from "../../../../shared/models/analyses/laboratory-analyses";
import {take} from "rxjs/operators";

@Component({
  selector: 'app-main',
  templateUrl: './analyses.component.html',
  styleUrls: ['./analyses.component.scss']
})
export class AnalysesComponent implements OnInit {

  public mainTableIsProgress: boolean = true;
  public dataSource: LaboratoryAnalyses[];

  constructor(private readonly _analyses: AnalysesService) { }

  ngOnInit(): void {
    this._analyses.getLaboratoryAnalyses().pipe(
      take(1)
    ).subscribe(res =>
    {
      this.dataSource = res.result;
      this.mainTableIsProgress = false;
    })
  }

  public onNameSearchKeyUp(): void{

  }
}

