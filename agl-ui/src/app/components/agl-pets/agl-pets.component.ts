import { Component, OnInit } from '@angular/core';

import { PetsByPersonGenderCollection, Gender, PetType } from '../../models/models';
import { PetsService } from '../../services/pets-service/pets-service';

@Component({
  selector: 'app-agl-pets',
  templateUrl: './agl-pets.component.html',
  styleUrls: ['./agl-pets.component.scss'],
  providers: [ PetsService ]
})
export class AglPetsComponent implements OnInit {

  petsByPersonGender: PetsByPersonGenderCollection;
  PetType : typeof 
  PetType = PetType; 
  genders: string[];
  selectedPetType: PetType;

  /******************************************/
  /* Constructor                            */
  /* petsService: The injected Pets Service */
  /******************************************/
  constructor(private petsService: PetsService) { }

  async ngOnInit() {
    try {
      this.petsByPersonGender = null;
      this.genders = [Gender[Gender.Male], Gender[Gender.Female]];      

      //call to API using injected Pets Service
      this.petsService.GetPetsByPersonGender(PetType.Dog).subscribe(x => {
        this.selectedPetType = PetType.Dog;
        this.petsByPersonGender = x;
      });
    }
    catch(e){
      alert(e);
    }
  }

  async getPets(petType: PetType)
  {
    this.petsService.GetPetsByPersonGender(petType).subscribe(x => {
      this.selectedPetType = petType;
      this.petsByPersonGender = x;
    });
  }

}
