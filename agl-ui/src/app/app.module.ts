import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';

import { AglPetsComponent } from './components/agl-pets/agl-pets.component';
import { PetsService } from './services/pets-service/pets-service';

import { AppConfigModule } from './app.config.module'

@NgModule({
  declarations: [
    AppComponent,
    AglPetsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AppConfigModule      
  ],
  providers: [PetsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
