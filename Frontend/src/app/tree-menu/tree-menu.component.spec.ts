import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TreeMenuComponent } from './tree-menu.component';

describe('TreeMenuComponent', () => {
  let component: TreeMenuComponent;
  let fixture: ComponentFixture<TreeMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TreeMenuComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TreeMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
