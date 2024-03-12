import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TreeMenuDinamicoComponent } from './tree-menu-dinamico.component';

describe('TreeMenuDinamicoComponent', () => {
  let component: TreeMenuDinamicoComponent;
  let fixture: ComponentFixture<TreeMenuDinamicoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TreeMenuDinamicoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TreeMenuDinamicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
