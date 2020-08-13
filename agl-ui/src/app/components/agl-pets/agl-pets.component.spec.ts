import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AglPetsComponent } from './agl-pets.component';
import { PetsService } from '../../services/pets-service/pets-service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

describe('AglPetsComponent', () => {
  let component: AglPetsComponent;
  let fixture: ComponentFixture<AglPetsComponent>;
  let petsService: PetsService;
  let http: HttpClient;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AglPetsComponent ],
      providers: [
        PetsService,
        HttpClient
      ],
      imports: [
        HttpClientModule
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {    
    http = TestBed.get(HttpClient);
    petsService = TestBed.get(PetsService) // Get the needed service    
    fixture = TestBed.createComponent(AglPetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
