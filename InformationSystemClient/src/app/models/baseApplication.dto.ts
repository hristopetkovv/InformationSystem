import { StatusType } from "../enums/statusType";

export class BaseApplicationDto {
    firstName: string;
    lastName: string;
    municipality: string;
    region: string;
    city: string;
    street: string;
    status: StatusType;
}