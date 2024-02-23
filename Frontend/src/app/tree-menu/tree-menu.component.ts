import { Component} from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Location } from '@angular/common';
 
@Component({
  selector: 'app-tree-menu',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './tree-menu.component.html',
  styleUrl: './tree-menu.component.css',
})
export class TreeMenuComponent {
  data: { [key: string]: Object }[] = [];
 
  constructor(private http: HttpClient, private location: Location) { }
 
  ngOnInit() {
    this.getMethod();
  }
 
  public getJsonValue: any;
 
  public getMethod() {
    this.http.get("https://localhost:7075/api/cliente").subscribe((data: any) => {
      console.log(data);
      this.getJsonValue = data;
      for (let i = 0; i < this.getJsonValue.length; i++) {
        let proyectos = [];
        let seguimientos = [];
        let licitaciones = [];
        for (let j = 0; j < this.getJsonValue[i].proyectos.length; j++) {
          let licitacionesProyecto = [];
          let seguimientosProyecto = [];
          for (let k = 0; k < this.getJsonValue[i].proyectos[j].length; k++) {
            seguimientosProyecto.push({ nodeId: String(i) + '-01-' + String(j) + '02-' + String(k), nodeText: this.getJsonValue[i].proyectos[j].seguimientos[k].nombre })
          }
          for (let k = 0; k < this.getJsonValue[i].proyectos[j].length; k++) {
            licitacionesProyecto.push({ nodeId: String(i) + '-01-' + String(j) + '03-' + String(k), nodeText: this.getJsonValue[i].proyectos[j].licitaciones[k].Nombrelicitacion })
          }
          proyectos.push({
            nodeId: String(i) + '-01-' + String(j), nodeText: this.getJsonValue[i].proyectos[j].nombre, nodeChild: [{ nodeId: String(i) + '-01-' + String(j) + '02-', nodeText: 'Seguimientos', nodeChild: seguimientosProyecto },
            { nodeId: String(i) + '-01-' + String(j) + '03-', nodeText: 'Licitaciones', nodeChild: licitacionesProyecto }]
          });
        }
        for (let j = 0; j < this.getJsonValue[i].seguimientos.length; j++) {
          seguimientos.push({ nodeId: String(i) + '-02-' + String(j), nodeText: this.getJsonValue[i].seguimientos[j].nombre })
        }
        for (let j = 0; j < this.getJsonValue[i].licitaciones.length; j++) {
          licitaciones.push({ nodeId: String(i) + '-03-' + String(j), nodeText: this.getJsonValue[i].licitaciones[j].Nombrelicitacion });
        }
        this.data.push({
          nodeId: String(i), nodeText: this.getJsonValue[i].nombre, nodeChild: [{ nodeId: String(i) + '-01', nodeText: 'Proyectos', nodeChild: proyectos },
          { nodeId: String(i) + '-02', nodeText: 'Seguimientos', nodeChild: seguimientos },
          { nodeId: String(i) + '-03', nodeText: 'Licitaciones', nodeChild: licitaciones }]
        })
      }
 
      // Clear the existing treeview content
      const treeviewElement = document.getElementById("treeview");
      if (treeviewElement) {
        treeviewElement.innerHTML = "";
        this.renderBootstrapTreeView(this.data, treeviewElement);
      }
 
      // Ocultar el elemento #loader una vez que los datos se hayan cargado
      const loaderElement = document.getElementById("loader");
      if (loaderElement) {
        loaderElement.style.display = "none";
      }
    }
    );
  }
 
 
 
  private renderBootstrapTreeView(data: any[], parentElement: HTMLElement) {
    data.forEach(item => {
      const listItem = document.createElement("li");
      listItem.classList.add("list-group-item");
      const icon = document.createElement("i");
      if (item.nodeChild && item.nodeChild.length > 0) { 
        icon.classList.add("bi", "bi-plus-circle", "me-2"); // Icono de 'plus' de Bootstrap
      } else {
        // Si el nodo no tiene hijos, añadir el evento click para el enrutamiento
        listItem.addEventListener('click', (event) => {
          event.stopPropagation();
          this.location.go(this.location.path() + '#' + item.nodeText);
          // Aquí puedes añadir la lógica para mostrar el nuevo componente
        });
      }
      listItem.appendChild(icon);
      const textSpan = document.createElement("span");
      textSpan.textContent = item.nodeText;
  
      listItem.appendChild(icon);
      listItem.appendChild(textSpan);
  
      if (item.nodeChild && item.nodeChild.length > 0) {
        // Añadir evento click para cambiar el ícono y colapsar/expandir elementos hijos
        listItem.addEventListener('click', (event) => {
          event.stopPropagation();
          if (icon.classList.contains('bi-plus-circle')) {
            icon.classList.replace('bi-plus-circle', 'bi-dash-circle');
          } else {
            icon.classList.replace('bi-dash-circle', 'bi-plus-circle');
          }
  
          sublist.style.display = sublist.style.display === 'none' ? '' : 'none';
        });
  
        const sublist = document.createElement("ul");
        sublist.classList.add("list-group", "ms-3"); // Añadir margen a la izquierda para los elementos hijos
        sublist.style.display = 'none'; // Ocultar inicialmente los elementos hijos
  
        this.renderBootstrapTreeView(item.nodeChild, sublist);
  
        listItem.appendChild(sublist);
      }
  
      parentElement.appendChild(listItem);
    });
  }  
}  
