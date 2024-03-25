import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatatableProyectosComponent } from './datatableProyectos.component';

describe('DatatablePoryectosComponent', () => {
  let component: DatatableProyectosComponent;
  let fixture: ComponentFixture<DatatableProyectosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DatatableProyectosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DatatableProyectosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
