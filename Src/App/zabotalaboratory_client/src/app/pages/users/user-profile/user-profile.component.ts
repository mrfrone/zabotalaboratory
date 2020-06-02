import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {UserProfile} from "../../../shared/models/users/user-profile";
import {MessageService} from "../../../core/services/message.service";
import {MatDialog} from "@angular/material/dialog";
import {UserProfileApiClient} from "../../../core/apiClient/users/user-profile.api-client";
import {DefaultSuccessMessages} from "../../../shared/consts/defaultSuccessMessages";
import {UpdateUserProfileForm} from "../../../shared/forms/profiles/update-user-profile.form";

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {

  public profileForm: FormGroup = new FormGroup({

    "abbreviatedNameOfCompany": new FormControl({value: '', disabled: true}),
    "fullNameOfCompany": new FormControl({value: '', disabled: true}),
    "email": new FormControl({value: '', disabled: true}),
    "address": new FormControl({value: '', disabled: true}),
    "changeUserProfileCheck": new FormControl()
  });

  public mainWindowIsProgress: boolean = true;
  public userProfile: UserProfile;

  constructor(private readonly _messages: MessageService,
              private readonly _dialog: MatDialog,
              private readonly _userProfile: UserProfileApiClient) { }

  ngOnInit(): void {
    this.updateData();
  }

  public onCheckBoxChanged(): void
  {
    if(this.profileForm.controls['changeUserProfileCheck'].value)
    {
      this.profileForm.controls['abbreviatedNameOfCompany'].setValidators(Validators.required);
      this.profileForm.controls['abbreviatedNameOfCompany'].enable();
      this.profileForm.controls['abbreviatedNameOfCompany'].updateValueAndValidity();

      this.profileForm.controls['fullNameOfCompany'].setValidators(Validators.required);
      this.profileForm.controls['fullNameOfCompany'].enable();
      this.profileForm.controls['fullNameOfCompany'].updateValueAndValidity();

      this.profileForm.controls['email'].setValidators([Validators.required, Validators.email]);
      this.profileForm.controls['email'].enable();
      this.profileForm.controls['email'].updateValueAndValidity();

      this.profileForm.controls['address'].setValidators(Validators.required);
      this.profileForm.controls['address'].enable();
      this.profileForm.controls['address'].updateValueAndValidity();
    }
    else {
      this.profileForm.controls['abbreviatedNameOfCompany'].setValidators(null);
      this.profileForm.controls['abbreviatedNameOfCompany'].disable();
      this.profileForm.controls['abbreviatedNameOfCompany'].updateValueAndValidity();

      this.profileForm.controls['abbreviatedNameOfCompany'].setValidators(null);
      this.profileForm.controls['fullNameOfCompany'].disable();
      this.profileForm.controls['fullNameOfCompany'].updateValueAndValidity();

      this.profileForm.controls['abbreviatedNameOfCompany'].setValidators(null);
      this.profileForm.controls['email'].disable();
      this.profileForm.controls['email'].updateValueAndValidity();

      this.profileForm.controls['abbreviatedNameOfCompany'].setValidators(null);
      this.profileForm.controls['address'].disable();
      this.profileForm.controls['address'].updateValueAndValidity();
    }
  }

  public onFormSubmit(): void {
    this.mainWindowIsProgress = true;

    const form: UpdateUserProfileForm = {
      abbreviatedNameOfCompany: this.profileForm.controls['abbreviatedNameOfCompany'].value,
      fullNameOfCompany: this.profileForm.controls['fullNameOfCompany'].value,
      email: this.profileForm.controls['email'].value,
      address: this.profileForm.controls['address'].value
    };
    this._userProfile.updateUserProfile(form).subscribe(res => {
      this._messages.showResult(res, DefaultSuccessMessages.onUpdateUserProfile);
      this.profileForm.reset();
      this.updateData();
    });
  }

  private updateData(): void{
    this._userProfile.getUserProfile()
      .subscribe(res => {
        if(res.isCorrect) {
          this.userProfile = res.result;

          this.profileForm.controls['abbreviatedNameOfCompany'].setValue(res.result.abbreviatedNameOfCompany);
          this.profileForm.controls['fullNameOfCompany'].setValue(res.result.fullNameOfCompany);
          this.profileForm.controls['email'].setValue(res.result.email);
          this.profileForm.controls['address'].setValue(res.result.address);
          this.profileForm.controls['changeUserProfileCheck'].setValue(false);

          this.onCheckBoxChanged();
        }
        else{
          this._messages.showMessage(res.error.message);
        }

        this.mainWindowIsProgress = false;
      });
  }
}
