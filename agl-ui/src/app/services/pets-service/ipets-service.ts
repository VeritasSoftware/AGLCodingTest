import { PetsByPersonGenderCollection, PetType } from '../../models/models'
import { Observable } from 'rxjs';

export interface IPetsService {
    GetPetsByPersonGender(petType: PetType): Observable<PetsByPersonGenderCollection>
    GetCatsByPersonGender(): Observable<PetsByPersonGenderCollection>;
}