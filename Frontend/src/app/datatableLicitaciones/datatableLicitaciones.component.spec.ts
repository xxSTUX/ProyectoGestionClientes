import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatatableLicitacionesComponent } from './datatableLicitaciones.component';

describe('DatatablePoryectosComponent', () => {
  let component: DatatableLicitacionesComponent;
  let fixture: ComponentFixture<DatatableLicitacionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DatatableLicitacionesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DatatableLicitacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
