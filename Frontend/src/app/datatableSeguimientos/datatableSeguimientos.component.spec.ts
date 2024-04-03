import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatatableSeguimientosComponent } from './datatableSeguimientos.component';

describe('DatatablePoryectosComponent', () => {
  let component: DatatableSeguimientosComponent;
  let fixture: ComponentFixture<DatatableSeguimientosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DatatableSeguimientosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DatatableSeguimientosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
