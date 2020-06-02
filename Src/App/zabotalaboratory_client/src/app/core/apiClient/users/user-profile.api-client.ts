import {Injectable} from "@angular/core";
import {BaseApiClient} from "../base.api-client";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ZabotaResult} from "../../../shared/models/zabota-result/zabota-result";
import {UserProfile} from "../../../shared/models/users/user-profile";
import {UpdateUserProfileForm} from "../../../shared/forms/profiles/update-user-profile.form";

@Injectable({providedIn: 'root'})

export class UserProfileApiClient extends BaseApiClient {
  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  public getUserProfile(): Observable<ZabotaResult<UserProfile>> {
    return this.get<ZabotaResult<UserProfile>>('/api/UserProfile/GetUserProfile');
  }

  public updateUserProfile(form: UpdateUserProfileForm): Observable<ZabotaResult<boolean>> {
    return this.post<ZabotaResult<boolean>, UpdateUserProfileForm>('/api/UserProfile/UpdateUserProfile', form);
  }

  public getCompanyName(): Observable<ZabotaResult<string>> {
    return this.get<ZabotaResult<string>>('/api/UserProfile/GetAbbreviatedNameOfCompany');
  }
}
