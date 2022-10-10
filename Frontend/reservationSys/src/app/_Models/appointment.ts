// import { Speciality } from './speciality';
import { Speciality } from "./speciality";
import { User } from "./user";

export class Appointment {
    constructor(
        public AppId:number,
        public UserId:number,
        public Date:Date,
        public SpecialityId:number=Number(),
        public Speciality:Speciality,
        public User:User,

    ){}
}
