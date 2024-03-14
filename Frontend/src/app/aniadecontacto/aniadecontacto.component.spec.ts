import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AniadecontactoComponent } from './aniadecontacto.component';

describe('AniadecontactoComponent', () => {
  let component: AniadecontactoComponent;
  let fixture: ComponentFixture<AniadecontactoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AniadecontactoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AniadecontactoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
