import { QualificationType } from "../enums/qualificationType";

export class QualificationInformation {
    qualificationId: string;
    startDate: Date;
    endDate: Date;
    durationDays: number;
    description: string;
    typeQualification: QualificationType;
}