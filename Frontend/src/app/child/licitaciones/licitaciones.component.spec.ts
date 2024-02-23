import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LicitacionesComponent } from './licitaciones.component';

describe('LicitacionesComponent', () => {
  let component: LicitacionesComponent;
  let fixture: ComponentFixture<LicitacionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LicitacionesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LicitacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
