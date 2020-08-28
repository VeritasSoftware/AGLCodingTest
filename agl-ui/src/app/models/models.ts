export class PetsByPersonGenderCollection {
    petsByPersonGender: PetsByPersonGender[];
}

export class PetsByPersonGender {
    gender: Gender;
    type: PetType;
    pets: Pet[];
}

export enum Gender {
    Male = 0,
    Female = 1
}

export class Pet
{
    name: string;    
}

export enum PetType
{
    Dog = 1,
    Cat = 2,
    Fish = 3
}