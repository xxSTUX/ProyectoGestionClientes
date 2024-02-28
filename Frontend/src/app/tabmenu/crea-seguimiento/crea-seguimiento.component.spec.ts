import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreaSeguimientoComponent } from './crea-seguimiento.component';

describe('CreaSeguimientoComponent', () => {
  let component: CreaSeguimientoComponent;
  let fixture: ComponentFixture<CreaSeguimientoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreaSeguimientoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreaSeguimientoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
