import { Injectable } from "@angular/core";
import { MessageStatus } from "src/app/enums/messageStatus";
import { BaseFilterDto } from "./baseFilterDto";

@Injectable({
    providedIn: 'root'
})

export class MesageSearchDto extends BaseFilterDto {
    content: string;
    startDate: string;
    endDate: string;
    status?: MessageStatus = null;
}