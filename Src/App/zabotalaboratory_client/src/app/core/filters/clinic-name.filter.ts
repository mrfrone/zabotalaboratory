import {Clinic} from "../../shared/models/analyses/clinic";

export class ClinicNameFilter {
  public static getName(id: number, clinics: Clinic[]): string {
    if(id == null) {
      return null;
    }

    return clinics.filter(c => c.id == id)[0].name
  }
}
