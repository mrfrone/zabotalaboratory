import {MatSnackBar} from "@angular/material/snack-bar";
import {Injectable} from "@angular/core";
import {BaseZabotaResult} from "../../shared/models/zabota-result/base-zabota-result";

@Injectable({providedIn: 'root'})
export class MessageService{
  constructor(private readonly _snackBar: MatSnackBar) { }

  public tryShowError(res: BaseZabotaResult): boolean {
    if (res.error === null || undefined) {
      return false;
    }

    this.showMessage(res.error.message);
    return true;
  }

  public showMessage(message: string): void{
    this._snackBar.open(message, '',{
      duration: 2000,
    });
  }
}
