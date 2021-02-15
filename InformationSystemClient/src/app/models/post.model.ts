import { PostStatus } from "../enums/PostStatus";

export class PostModel {
    id: number;
    content: string;
    startDate: Date;
    endDate: Date;
    status: PostStatus;
}