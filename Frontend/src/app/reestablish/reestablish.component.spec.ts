import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReestablishComponent } from './reestablish.component';

describe('ReestablishComponent', () => {
  let component: ReestablishComponent;
  let fixture: ComponentFixture<ReestablishComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReestablishComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ReestablishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
