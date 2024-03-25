import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreaSeguiminetoComponent } from './crea-seguimineto.component';

describe('CreaSeguiminetoComponent', () => {
  let component: CreaSeguiminetoComponent;
  let fixture: ComponentFixture<CreaSeguiminetoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreaSeguiminetoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreaSeguiminetoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
