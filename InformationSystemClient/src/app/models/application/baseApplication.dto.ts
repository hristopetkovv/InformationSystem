import { StatusType } from "src/app/enums/statusType";

export class BaseApplicationDto {
    id: string;
    firstName: string;
    lastName: string;
    municipality: string;
    region: string;
    city: string;
    street: string;
    userId: number;
    status: StatusType;
}