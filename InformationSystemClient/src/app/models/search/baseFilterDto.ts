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
