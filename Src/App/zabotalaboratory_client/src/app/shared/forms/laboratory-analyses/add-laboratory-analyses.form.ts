import {AddTalonsForm} from "./add-talons.form";

export class AddLaboratoryAnalysesForm {
  public firstName: string;
  public lastName: string;
  public patronymicName: string;
  public dateOfBirth: string;
  public genderId: number;
  public clinicId: number;
  public doctor: string;
  public talons: AddTalonsForm[];
}
