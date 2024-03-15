import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModificaclienteComponent } from './modificacliente.component';

describe('ModificaclienteComponent', () => {
  let component: ModificaclienteComponent;
  let fixture: ComponentFixture<ModificaclienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModificaclienteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModificaclienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
