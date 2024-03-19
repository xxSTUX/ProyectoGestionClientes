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
      row.classList.add('row','pt-2');
      console.log(data[i]);
      contanier.appendChild(row); // Agrega el option al elemento select
      const col = document.createElement('div')
      col.classList.add('col-2', 'font-weight-bold', 'small', 'text-centre')
      row.appendChild(col)
      col.textContent = data[i].nombre;

      const linea = document.createElement('hr');
      contanier.appendChild(linea);

      const col1 = document.createElement('div');
      col1.classList.add('col-2');
      row.appendChild(col1);
      col1.textContent = "1";


      const col2 = document.createElement('div');
      col2.classList.add('col-2');
      row.appendChild(col2);
      col2.textContent = "2";
       
      const col3 = document.createElement('div');
      col3.classList.add('col-3');
      row.appendChild(col3);
      col3.textContent = "16/12/2002";

      const col4 = document.createElement('div');
      col4.classList.add('col-2');

      const icon = document.createElement('i');
      icon.classList.add('bi','bi-building-gear','h3');
      icon.onclick = editarCliente;
      col4.appendChild(icon);

      const icon1 = document.createElement('i');
      icon1.classList.add('col-1');
      icon1.classList.add('bi','bi-building-x','h3');
      icon1.onclick = eliminarCliente;
      col4.appendChild(icon1);

      const icon2 = document.createElement('i');
      icon2.classList.add('bi','bi-clipboard-plus','h3');
      dev-funcionalidad-botones-home
      icon2.onclick = crearSeguimiento;
      col4.appendChild(icon2);
      row.appendChild(col4);

      // const icon = document.createElement('i');
      // icon.classList.add('col-1',);
      // icon.classList.add('bi','bi-building-gear','h3');
      // icon.onclick = editarCliente;
      // col1.appendChild(icon);
      
      // const icon1 = document.createElement('i');
      // icon1.classList.add('col-1');
      // icon1.classList.add('bi','bi-building-x','h3');
      // icon1.onclick = eliminarCliente;
      // col1.appendChild(icon1);

      // const icon2 = document.createElement('i');
      // icon2.classList.add('col-1');
      // icon2.classList.add('bi','bi-clipboard-plus','h3');
      // icon2.onclick = crearSeguimiento;
      // col1.appendChild(icon2);


      function eliminarCliente(){

      }
      
      function editarCliente(){

      }
      function crearSeguimiento(){
        alert();
      }

      


    }
    
  }
    });

      col1.appendChild(icon2);
    }  
  }});

 }
}
