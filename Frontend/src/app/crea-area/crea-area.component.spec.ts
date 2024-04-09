import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreaAreaComponent } from './crea-area.component';

describe('CreaAreaComponent', () => {
  let component: CreaAreaComponent;
  let fixture: ComponentFixture<CreaAreaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreaAreaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreaAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
