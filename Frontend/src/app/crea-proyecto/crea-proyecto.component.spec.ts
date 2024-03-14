import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreaProyectoComponent } from './crea-proyecto.component';


describe('CreaProyectoComponent', () => {
  let component: CreaProyectoComponent;
  let fixture: ComponentFixture<CreaProyectoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreaProyectoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreaProyectoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
