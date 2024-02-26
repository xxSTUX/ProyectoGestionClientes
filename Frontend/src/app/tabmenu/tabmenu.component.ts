import { Component } from '@angular/core';
import { TreeMenuComponent } from '../tree-menu/tree-menu.component';
import { SideMenuComponent } from '../side-menu/side-menu.component';
import { HeaderComponent } from '../header/header.component';
import { HttpClientModule} from '@angular/common/http';
import { AngularEditorConfig, AngularEditorModule } from '@kolkov/angular-editor';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tabmenu',
  standalone: true,
  imports: [HeaderComponent, SideMenuComponent, TreeMenuComponent,HttpClientModule, AngularEditorModule, FormsModule],
  templateUrl: './tabmenu.component.html',
  styleUrl: './tabmenu.component.css'
})
export class TabmenuComponent {

  id:string = '';
  fechaCre: string = '';
  fechaMod: string = '';
  usuario: string = '';
  usuarioMod: string = '';
  nombre: string = '';
  texto: string= '';

  constructor(private router: Router) {}

  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '32vh',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    defaultParagraphSeparator: 'p',
    defaultFontName: 'Arial',  
    toolbarHiddenButtons:[
      [
        'insertImage',
        'insertVideo',
      ]
    ]
  };

  public create(){
    alert("Llamar a funcion: createSeguimiento("+this.id+","+this.usuario+","+this.nombre+","+this.texto);
  }

  public delete(){
    //borrarSeguimiento(this.id);
  }

  public cancel(){
    this.router.navigate(["login"]);
  }

}
