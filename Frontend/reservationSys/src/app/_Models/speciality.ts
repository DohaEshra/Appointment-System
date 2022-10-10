import { Appointment } from "./appointment";

export class Speciality {
    constructor(
            public SpecialityId:number,
            public SpecialityName:string,
            public Appointments:Appointment[]= [],
    ){}
}
