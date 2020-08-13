import {Injectable, Inject} from '@angular/core'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IPetsService } from './ipets-service';
import { PetsByPersonGenderCollection, PetType } from '../../models/models';
import { APP_CONFIG, AppConfig } from '../../app.config.module';

@Injectable()
export class PetsService implements IPetsService {
    /*********************************/
    /* Constructor                   */
    /* http: The injected HttpClient */
    /*********************************/
    constructor(private http: HttpClient, @Inject(APP_CONFIG) private config: AppConfig){

    }

    /**************************************************/
    /* Get the pets by pet type and by owner's gender */
    /* Make http call to API                          */
    /**************************************************/
    private GetPetsByPersonGender(petType: PetType): Observable<PetsByPersonGenderCollection> {
        var url = this.config.apiEndpoint + "petsbypersongender/" + petType.toString();

        //http call to API using HttpClient
        return this.http.get<PetsByPersonGenderCollection>(url);
    }  

    public GetCatsByPersonGender(): Observable<PetsByPersonGenderCollection> {
        return this.GetPetsByPersonGender(PetType.Cat);
    }
}