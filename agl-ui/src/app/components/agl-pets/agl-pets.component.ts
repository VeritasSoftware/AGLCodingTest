import { Component, OnInit } from '@angular/core';
import { trigger, style, animate, transition} from '@angular/animations';

import { PetsByPersonGenderCollection, Gender, PetType } from '../../models/models';
import { PetsService } from '../../services/pets-service/pets-service';

@Component({
  selector: 'app-agl-pets',
  templateUrl: './agl-pets.component.html',
  styleUrls: ['./agl-pets.component.scss'],
  animations: [
    trigger('fade', [ 
      transition('void => *', [
        style({ opacity: 0 }), 
        animate(2000, style({opacity: 1}))
      ]) 
    ])
  ],
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

      this.getPets(PetType.Dog);
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
