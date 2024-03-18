import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  constructor(private router: Router, private http: HttpClient,private apiService: ApiService){

  }
  ngOnInit(){
    this.crearTabla();
  }
 crearTabla(){
  const contanier = document.getElementById("clientes") as HTMLOptionElement;
  this.apiService.getDataClientesFromAPI().subscribe((data: any) =>{
  if(contanier != null){
    for (let i = 0; i < data.length; i++) {
      const row = document.createElement('div');
      row.classList.add('row','mt-3');
      console.log(data[i]);
      contanier.appendChild(row); // Agrega el option al elemento select
      const col = document.createElement('div')
      col.classList.add('col-9')
      row.appendChild(col)
      col.textContent = data[i].nombre;

      const linea = document.createElement('hr');
      contanier.appendChild(linea);

      const col1 = document.createElement('div');
      col1.classList.add('col-3');
      row.appendChild(col1);

      const icon = document.createElement('i');
      icon.classList.add('col-1',);
      icon.classList.add('bi','bi-building-gear','h3');
      col1.appendChild(icon);
      
      const icon1 = document.createElement('i');
      icon1.classList.add('col-1');
      icon1.classList.add('bi','bi-building-add','h3');
      col1.appendChild(icon1);

      const icon2 = document.createElement('i');
      icon2.classList.add('col-1');
      icon2.classList.add('bi','bi-clipboard-plus','h3');
      col1.appendChild(icon2);
    }  
  }});
 }
}
