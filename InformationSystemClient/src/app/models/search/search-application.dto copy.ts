import { Injectable } from "@angular/core";
import { StatusType } from "src/app/enums/statusType";
import { BaseFilterDto } from "./baseFilterDto";

@Injectable({
    providedIn: 'root'
})

export class SearchApplicationDto extends BaseFilterDto {
    status?: StatusType = null;
    firstName: string;
    lastName: string;
    city: string;
    municipality: string;
    region: string;
}