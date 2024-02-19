import { Component } from '@angular/core';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';
import { SideMenuComponent } from '../side-menu/side-menu.component';
import { HeaderComponent } from '../header/header.component';
import { HttpClientModule} from '@angular/common/http';
import { AngularEditorConfig, AngularEditorModule } from '@kolkov/angular-editor';

@Component({
  selector: 'app-tabmenu',
  standalone: true,
  imports: [HeaderComponent, SideMenuComponent, TreeMenuComponent,HttpClientModule, AngularEditorModule],
  templateUrl: './tabmenu.component.html',
  styleUrl: './tabmenu.component.css'
})
export class TabmenuComponent {
  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '15rem',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    defaultParagraphSeparator: 'p',
    defaultFontName: 'Arial',
   
  };

}
