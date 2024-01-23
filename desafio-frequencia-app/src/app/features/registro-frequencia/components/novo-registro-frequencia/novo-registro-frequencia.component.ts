import { Component } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-novo-registro-frequencia',
  templateUrl: './novo-registro-frequencia.component.html',
  styleUrl: './novo-registro-frequencia.component.css',
})
export class NovoRegistroFrequenciaComponent {

  dataForm = this.formBuilder.group({
    dataRegistro: ['', Validators.required],
  });

  constructor(private formBuilder: FormBuilder) {}

  getDataRegistoFormControl() : string | null | undefined {
    return this.dataForm.get('dataRegistro')?.value
  }

  updateDataRegistoFormControl(value: any) {
    this.dataForm.get('dataRegistro')?.setValue(value);
  }
}
