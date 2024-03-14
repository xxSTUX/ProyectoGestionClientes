import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EliminaProyectoComponent } from './elimina-proyecto.component';

describe('EliminaProyectoComponent', () => {
  let component: EliminaProyectoComponent;
  let fixture: ComponentFixture<EliminaProyectoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EliminaProyectoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EliminaProyectoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
