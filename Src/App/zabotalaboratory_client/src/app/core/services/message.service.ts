import {MatSnackBar} from "@angular/material/snack-bar";
import {Injectable} from "@angular/core";
import {BaseZabotaResult} from "../../shared/models/zabota-result/base-zabota-result";

@Injectable({providedIn: 'root'})
export class MessageService{
  constructor(private readonly _snackBar: MatSnackBar) { }

  public showMessage(message: string): void{
    this._snackBar.open(message, '',{
      duration: 2000,
    });
  }

  public showResult<TRes extends BaseZabotaResult>(result: TRes, successMessage: string): void{
    if (result.isCorrect === true){
      this.showMessage(successMessage);
    }
    else{
      this.showMessage(result.error.message);
    }
  }
}
