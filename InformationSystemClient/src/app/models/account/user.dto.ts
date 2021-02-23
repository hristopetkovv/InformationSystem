import { Role } from "src/app/enums/role";

export interface UserDto {
    id: number;
    username: string;
    token: string;
    role: Role;
    firstName: string;
    lastName: string;
}