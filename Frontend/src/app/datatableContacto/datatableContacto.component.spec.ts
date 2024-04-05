import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatatableContactoComponent } from './datatableContacto.component';

describe('DatatablePoryectosComponent', () => {
  let component: DatatableContactoComponent;
  let fixture: ComponentFixture<DatatableContactoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DatatableContactoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DatatableContactoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
