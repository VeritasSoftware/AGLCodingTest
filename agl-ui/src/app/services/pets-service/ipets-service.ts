import { PetsByPersonGenderCollection } from '../../models/models'
import { Observable } from 'rxjs';

export interface IPetsService {
    GetCatsByPersonGender(): Observable<PetsByPersonGenderCollection>;
}