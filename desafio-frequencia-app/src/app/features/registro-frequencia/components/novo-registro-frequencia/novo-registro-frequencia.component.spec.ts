import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoRegistroFrequenciaComponent } from './novo-registro-frequencia.component';

describe('NovoRegistroFrequenciaComponent', () => {
  let component: NovoRegistroFrequenciaComponent;
  let fixture: ComponentFixture<NovoRegistroFrequenciaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NovoRegistroFrequenciaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NovoRegistroFrequenciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
