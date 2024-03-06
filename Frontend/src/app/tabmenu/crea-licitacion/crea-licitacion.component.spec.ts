import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreaLicitacionComponent } from './crea-licitacion.component';

describe('CreaLicitacionComponent', () => {
  let component: CreaLicitacionComponent;
  let fixture: ComponentFixture<CreaLicitacionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreaLicitacionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreaLicitacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
