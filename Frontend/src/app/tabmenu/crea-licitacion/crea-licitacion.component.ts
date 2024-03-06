import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AngularEditorConfig, AngularEditorModule } from '@kolkov/angular-editor';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-crea-licitacion',
  standalone: true,
  imports: [AngularEditorModule,FormsModule, HttpClientModule],
  templateUrl: './crea-licitacion.component.html',
  styleUrl: './crea-licitacion.component.css'
})
export class CreaLicitacionComponent {

  id:string = '1';
  nombre: string = '';
  tipo: string= '';

  constructor(private router: Router, private http: HttpClient, private apiService: ApiService) {
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
      tipo: this.tipo
    }
    console.log(this.apiService.postLicitacionFromAPI(body.nombre,body.tipo));
  }

  public delete(){
    //borrarSeguimiento(this.id);
  }

  public cancel(){
    this.router.navigate(["login"]);
  }
}
