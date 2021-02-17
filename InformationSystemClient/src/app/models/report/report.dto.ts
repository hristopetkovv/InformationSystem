import { StatusType } from "../../enums/statusType";

export class ReportDto {
    applicationId: number;
    firstName: string;
    lastName: string;
    municipality: string;
    region: string;
    city: string;
    street: string;
    totalCourseDays: number;
    totalInternshipDays: number;
    status: StatusType;
}