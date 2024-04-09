import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreaContactoComponent } from './crea-contacto.component';


describe('CreaContactoComponent', () => {
  let component: CreaContactoComponent;
  let fixture: ComponentFixture<CreaContactoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreaContactoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreaContactoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
