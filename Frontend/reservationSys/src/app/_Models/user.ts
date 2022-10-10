import { Appointment } from "./appointment";

export class User {
    constructor(
        public UserId:number=Number(),
        public Username:string,
        public Password:string,
        public FName:string,
        public LName:string,
        public Appointments:Appointment[]=[],
    ){}
}

