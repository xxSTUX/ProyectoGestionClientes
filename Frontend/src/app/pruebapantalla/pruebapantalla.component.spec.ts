import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PruebapantallaComponent } from './pruebapantalla.component';

describe('PruebapantallaComponent', () => {
  let component: PruebapantallaComponent;
  let fixture: ComponentFixture<PruebapantallaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PruebapantallaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PruebapantallaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
