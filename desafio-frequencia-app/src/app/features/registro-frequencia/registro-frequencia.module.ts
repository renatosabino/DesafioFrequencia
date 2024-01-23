import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NovoRegistroFrequenciaComponent } from './components/novo-registro-frequencia/novo-registro-frequencia.component';

import { MatFormFieldModule } from "@angular/material/form-field";
import { MatButtonModule } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, provideNativeDateAdapter } from '@angular/material/core';
import { MatCardModule } from '@angular/material/card';



@NgModule({
  declarations: [NovoRegistroFrequenciaComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatStepperModule,
    MatFormFieldModule,    
    ReactiveFormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCardModule
  ],
  exports: [NovoRegistroFrequenciaComponent],  
  providers: [provideNativeDateAdapter()],
})
export class RegistroFrequenciaModule { }