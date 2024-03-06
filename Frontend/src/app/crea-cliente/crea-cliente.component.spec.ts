import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreaClienteComponent } from './crea-cliente.component';

describe('CreaClienteComponent', () => {
  let component: CreaClienteComponent;
  let fixture: ComponentFixture<CreaClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreaClienteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreaClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
