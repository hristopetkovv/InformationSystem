import { MessageStatus } from "../../enums/messageStatus";

export class MessageModel {
    id: number;
    content: string;
    startDate: Date;
    endDate: Date;
    status: MessageStatus;
}