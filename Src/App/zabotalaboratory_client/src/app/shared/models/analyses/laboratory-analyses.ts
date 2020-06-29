import { Clinic } from './clinic';
import { Talons } from './talons';
import {Gender} from "./gender";
import {MedicalRecord} from "./medical-record";

export class LaboratoryAnalyses{
  public id: number;
  public lastName: string;
  public firstName: string;
  public patronymicName: string;
  public fullName: string;
  public dateOfBirth: Date;
  public gender: Gender;
  public clinicId: number;
  public clinic: Clinic;
  public pickUpDate: Date;
  public talons: Talons[];
  public doctor: string;
  public medicalRecord: MedicalRecord;
  public isValid: boolean;
}
