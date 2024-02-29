import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaSeguimientosComponent } from './lista-seguimientos.component';

describe('ListaSeguimientosComponent', () => {
  let component: ListaSeguimientosComponent;
  let fixture: ComponentFixture<ListaSeguimientosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListaSeguimientosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListaSeguimientosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
