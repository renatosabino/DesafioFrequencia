import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './core/components/header/header.component';
import { RegistroFrequenciaModule } from './features/registro-frequencia/registro-frequencia.module';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [CommonModule, RouterOutlet, HeaderComponent, RegistroFrequenciaModule]
})
export class AppComponent {
  title = 'desafio-frequencia-app';
}
