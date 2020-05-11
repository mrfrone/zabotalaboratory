import {MatSnackBar} from "@angular/material/snack-bar";
import {Injectable} from "@angular/core";

@Injectable({providedIn: 'root'})
export class MessageService{
  constructor(private readonly _snackBar: MatSnackBar) { }

  public showMessage(message: string): void{
    this._snackBar.open(message, '',{
      duration: 2000,
    });
  }
}
