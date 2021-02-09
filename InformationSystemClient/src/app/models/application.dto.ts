import { StatusType } from "../enums/statusType";

export interface ApplicationDto {
    firstName: string,
    lastName: string,
    municipality: string,
    region: string,
    city: string,
    street: string,
    status: StatusType
}