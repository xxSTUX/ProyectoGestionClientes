import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { AngularEditorConfig, AngularEditorModule } from '@kolkov/angular-editor';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-crea-seguimiento',
  standalone: true,
  imports: [AngularEditorModule,FormsModule, HttpClientModule],
  templateUrl: './crea-seguimiento.component.html',
  styleUrl: './crea-seguimiento.component.css'
})
export class CreaSeguimientoComponent {
  id:string = '';
  fechaCre: string = '';
  fechaMod: string = '';
  usuario: string = '';
  usuarioMod: string = '';
  nombre: string = '';
  texto: string= '';

  constructor(private router: Router, private http: HttpClient) {
    // ,@Inject(Number) public _id?:string
    // if (_id != null) this.id = _id;
  }

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
    //alert("Llamar a funcion: createSeguimiento("+this.id+","+this.usuario+","+this.nombre+","+this.texto);
    const body = {
      nombre: this.nombre,
      tipo: this.texto
    }
    this.http.post("https://localhost:7075/api/cliente", body);
  }

  public delete(){
    //borrarSeguimiento(this.id);
  }

  public cancel(){
    this.router.navigate(["login"]);
  }

}
