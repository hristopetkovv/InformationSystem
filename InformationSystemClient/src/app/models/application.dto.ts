import { ApplicationType } from "../enums/applicationType";
import { StatusType } from "../enums/statusType";
import { QualificationInformation } from "./qualificationInformation.dto";

export class ApplicationDto {
    id: number;
    firstName: string;
    lastName: string;
    applicationType: ApplicationType;
    status: StatusType;
    municipality: string;
    region: string;
    city: string;
    street: string;
    userFirstName: string;
    userLastName: string;
    qualificationInformation: QualificationInformation[] = [];;
}