import { Component} from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Location } from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-tree-menu',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './tree-menu.component.html',
  styleUrl: './tree-menu.component.css',
})
export class TreeMenuComponent {
  data: { [key: string]: Object }[] = [];

  constructor(private http: HttpClient, private location: Location,private router: Router) { }

  ngOnInit() {
    this.getMethod();
  }

  public getJsonValue: any;

  public getMethod() {
    this.http.get("https://localhost:7075/api/cliente").subscribe((data: any) => {
        this.getJsonValue = data;
        for (let i = 0; i < this.getJsonValue.length; i++) { // Recorre clientes
            let proyectos = [];
            let seguimientos = [];
            let licitaciones = [];
            for (let j = 0; j < this.getJsonValue[i].proyectos.length; j++) { // Recorre proyectos del cliente
                let licitacionesProyecto = [];
                let seguimientosProyecto = [];
                for (let k = 0; k < this.getJsonValue[i].proyectos[j].seguimientos.length; k++) { // Recorre seguimientos dentro del proyecto
                    seguimientosProyecto.push({ nodeId: this.getJsonValue[i].proyectos[j].seguimientos[k].id, nodeText: this.getJsonValue[i].proyectos[j].seguimientos[k].nombre })
                }
                for (let k = 0; k < this.getJsonValue[i].proyectos[j].licitaciones.length; k++) { // Recorre licitaciones dentro del proyecto
                    licitacionesProyecto.push({ nodeId: this.getJsonValue[i].proyectos[j].licitaciones[k].id, nodeText: this.getJsonValue[i].proyectos[j].licitaciones[k].nombre })
                }
                proyectos.push({
                    nodeId: this.getJsonValue[i].proyectos[j].id, nodeText: this.getJsonValue[i].proyectos[j].nombre, nodeChild: [{ nodeId: this.getJsonValue[i].proyectos[j].id, nodeText: 'Seguimientos', nodeChild: seguimientosProyecto },
                    { nodeId: this.getJsonValue[i].proyectos[j].id, nodeText: 'Licitaciones', nodeChild: licitacionesProyecto }]
                });
            }
            for (let j = 0; j < this.getJsonValue[i].seguimientos.length; j++) { // Recorre seguimientos del cliente
                seguimientos.push({ nodeId: this.getJsonValue[i].seguimientos[j].id, nodeText: this.getJsonValue[i].seguimientos[j].nombre })
            }
            for (let j = 0; j < this.getJsonValue[i].licitaciones.length; j++) { // Recorre licitaciones del cliente
                licitaciones.push({ nodeId: this.getJsonValue[i].licitaciones[j].id, nodeText: this.getJsonValue[i].licitaciones[j].nombre });
            }
            this.data.push({
                nodeId: this.getJsonValue[i].id, nodeText: this.getJsonValue[i].nombre, nodeChild: [{ nodeId: this.getJsonValue[i].id, nodeText: 'Proyectos', nodeChild: proyectos },
                { nodeId: this.getJsonValue[i].id, nodeText: 'Seguimientos', nodeChild: seguimientos },
                { nodeId: this.getJsonValue[i].id, nodeText: 'Licitaciones', nodeChild: licitaciones }]
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




  private renderBootstrapTreeView(data: any[], parentElement: HTMLElement, parentNode?: any) {
    data.forEach(item => {
      this.location.go(this.location.path() + '#' + item.nodeText);//Cambio de la ruta mostrada
      const listItem = document.createElement("li");
      listItem.classList.add("list-group-item");
      const icon = document.createElement("i");

      if (item.nodeChild && item.nodeChild.length > 0) {
        icon.classList.add("bi", "bi-plus-circle", "me-2"); // Icono de 'plus' de Bootstrap
      } else {
        // Si el nodo no tiene hijos, añadir el evento click para el enrutamiento
        listItem.addEventListener('click', (event) => {
          event.stopPropagation();
          // Obtener el padre
          //Contemplar que todo padre que nosea licitaciones,seguimientos,... sea cliene para que funcione bien
          let itemPadre = parentNode.nodeText;
          if (!(itemPadre === 'Proyectos' || itemPadre === 'Seguimientos' || itemPadre === 'Licitaciones')) {
          itemPadre = 'Cliente';
          }

          this.location.go(this.location.path() + '#' + itemPadre + '=' + item.nodeId);//Cambio de la ruta mostrada, mostrar la del padre del item TODO-Gian quitar a aprtir del = en la fragmet para tratar el componente mostrado
          const newPath = this.location.path() + '#' + itemPadre + '=' + item.nodeId;//conseguir la ruta padre del item + el id del elemento clickado
          // Aquí puedes añadir la lógica para mostrar el nuevo componente
          alert('Nodo: ' +  itemPadre + ' ID:' + item.nodeId);
          console.log('ID del nodo clicado:', item.nodeId);


          // Obtener el padre del nodo que ya no tiene mas hijos, el elemento padre del que depende el item que tiene el evento de click
          if (parentNode) {
            console.log('El padre del nodo sin hijos es:', itemPadre);
          }
          this.router.navigateByUrl(newPath);//Provocar un navigationEnd para que se actualice el div dinamico que muestra un componente u otro
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

        this.renderBootstrapTreeView(item.nodeChild, sublist, item);

        listItem.appendChild(sublist);
      }

      parentElement.appendChild(listItem);
    });
  }


}
