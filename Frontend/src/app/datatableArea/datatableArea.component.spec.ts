import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatatableAreaComponent } from './datatableArea.component';

describe('DatatablePoryectosComponent', () => {
  let component: DatatableAreaComponent;
  let fixture: ComponentFixture<DatatableAreaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DatatableAreaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DatatableAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
