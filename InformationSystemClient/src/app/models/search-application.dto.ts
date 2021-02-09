import { Injectable } from "@angular/core";
import { StatusType } from "../enums/statusType";

export abstract class BaseFilterDto {
    getQueryString(): string {
        let params = '';
        Object.keys(this)
            .filter(key => this[key])
            .forEach((key: string, i: number) => {
                if (this[key]) {
                    params += i === 0 ? '?' : '&';
                    params += `${key}=${this[key]}`;
                }
            });

        return params;
    }
}

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