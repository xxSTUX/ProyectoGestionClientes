import { Component } from '@angular/core';
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

  constructor(private http: HttpClient, private location: Location, private router: Router) { }

  ngOnInit() {
    this.getMethod();
  }

  public getJsonValue: any;

  public getMethod() {
    this.http.get("https://localhost:7075/api/cliente").subscribe((data: any) => {
      this.getJsonValue = data;
      for (let i = 0; i < this.getJsonValue.length; i++) { //Recorre clientes
        let proyectos = [];
        let seguimientos = [];
        let licitacionesEnEstudio = [];
        let licitacionesGanadas = [];
        let licitacionesPerdidas = [];
        let clienteId = this.getJsonValue[i].id; // Obtener el ID del cliente

        for (let j = 0; j < this.getJsonValue[i].proyectos.length; j++) { //Recorre proyectos del cliente
          let licitacionesProyecto = [];
          let seguimientosProyecto = [];
          for (let k = 0; k < this.getJsonValue[i].proyectos[j].seguimientos.length; k++) { //Recorre seguimientos dentro del proyecto
            seguimientosProyecto.push({ nodeId: clienteId + "-" + this.getJsonValue[i].proyectos[j].seguimientos[k].id, nodeText: this.getJsonValue[i].proyectos[j].seguimientos[k].nombre })
          }
          for (let k = 0; k < this.getJsonValue[i].proyectos[j].licitaciones.length; k++) { //Recorre licitaciones dentro del proyecto
            licitacionesProyecto.push({ nodeId: clienteId + "-" + this.getJsonValue[i].proyectos[j].licitaciones[k].id, nodeText: this.getJsonValue[i].proyectos[j].licitaciones[k].nombre })
          }
          proyectos.push({
            nodeId: clienteId + '-' + this.getJsonValue[i].proyectos[j].id, nodeText: this.getJsonValue[i].proyectos[j].nombre, nodeChild: [{ nodeId: clienteId + '-' + this.getJsonValue[i].proyectos[j].id, nodeText: 'Seguimientos', nodeChild: seguimientosProyecto },
            { nodeId: clienteId + '-' + this.getJsonValue[i].proyectos[j].id, nodeText: 'Licitaciones', nodeChild: licitacionesProyecto }]
          });
        }
        for (let j = 0; j < this.getJsonValue[i].seguimientos.length; j++) { // Recorre seguimientos del cliente
          seguimientos.push({ nodeId: clienteId + '-' + this.getJsonValue[i].seguimientos[j].id, nodeText: this.getJsonValue[i].seguimientos[j].nombre })
      }
        for (let j = 0; j < this.getJsonValue[i].licitaciones.length; j++) { //Recorre licitaciones del cliente
          switch (this.getJsonValue[i].licitaciones[j].ganada) {
            case 0:
              licitacionesEnEstudio.push({ nodeId: clienteId + '-' + this.getJsonValue[i].licitaciones[j].id, nodeText: this.getJsonValue[i].licitaciones[j].nombre });
              break;
            case 1:
              licitacionesGanadas.push({ nodeId: clienteId + '-' + this.getJsonValue[i].licitaciones[j].id, nodeText: this.getJsonValue[i].licitaciones[j].nombre });
              break;
            case 2:
              licitacionesPerdidas.push({ nodeId: clienteId + '-' + this.getJsonValue[i].licitaciones[j].id, nodeText: this.getJsonValue[i].licitaciones[j].nombre });
              break;
          }
        }
        let licitaciones = [];
        if(licitacionesEnEstudio.length > 0){
          licitaciones.push({nodeId: "", nodeText: 'En estudio', nodeChild: licitacionesEnEstudio})
        }
        if(licitacionesGanadas.length > 0){
          licitaciones.push({nodeId: "", nodeText: 'Ganadas', nodeChild: licitacionesGanadas})
        }
        if(licitacionesPerdidas.length > 0){
          licitaciones.push({nodeId: "", nodeText: 'Perdidas', nodeChild: licitacionesPerdidas})
        }
        this.data.push({
          nodeId: "*", nodeText: this.getJsonValue[i].nombre, nodeChild: [{ nodeId: clienteId, nodeText: 'Proyectos', nodeChild: proyectos },
          { nodeId: clienteId, nodeText: 'Seguimientos', nodeChild: seguimientos },
          { nodeId: clienteId, nodeText: 'Licitaciones', nodeChild: licitaciones
          }]
        })

      }
      console.log("Hola gianfranco");
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
      //this.location.go(this.location.path() + '#' + item.nodeText);//Cambio de la ruta mostrada
      const listItem = document.createElement("li");
      listItem.classList.add("list-group-item");
      const icon = document.createElement("i");
      let nodePath = "";

      if (!parentNode) {//Si el nodo no tiene padre, la ruta la cambia al nombre del nodo (lo guardo en el campo textContent para poder utilizarlo luego)
        item.textContent ="Cliente/" + item.nodeText;
      }
      else{ //Si
        item.textContent = parentNode.textContent + "/" + item.nodeText; // Concatenar el nombre del padre a la ruta
      }

      if (item.nodeChild && item.nodeChild.length > 0) {

        icon.classList.add("bi", "bi-plus-circle", "me-2"); // Icono de 'plus' de Bootstrap
        listItem.addEventListener('click', (event) => { //Para poder clicar en el texto de un nodo y que cambie la ruta, independientemente de si es hijo o no
          event.stopPropagation();

          this.location.go(this.location.path() + '#' + item.textContent); // Cambiamos la ruta parentNode.Text + "/" +
          //window.location.href = newPath; // Actualizamos la ruta en consecuencia al nombre
        }); //Hasta aqui
      } else {
        // Si el nodo no tiene hijos, añadir el evento click para el enrutamiento
        listItem.addEventListener('click', (event) => {
          event.stopPropagation();
          // Obtener el padre
          //Contemplar que todo padre que nosea licitaciones,seguimientos,... sea cliene para que funcione bien si no es ninguno de estos buscar el cliente
          let itemPadre = parentNode.nodeText;
          let itemId = item.nodeId.toString();
          if (!(itemPadre === 'Proyectos' || itemPadre === 'Seguimientos' || itemPadre === 'Licitaciones')) {
            itemPadre = 'Cliente';
            itemId = itemId.split("-")[0];
            alert('No existen: ' +  item.nodeText + ' para:' + parentNode.nodeText);
          }else{
            console.log('else:', itemId);
            itemId = itemId.split("-")[1];
          }
          this.location.go(this.location.path() + '#' +  item.textContent + '#' + '/' + itemPadre + '=' +  itemId ); // Cambiamos la ruta parentNode.Text + "/" +
          const newPath = (this.location.path() + '#' +  item.textContent + '#' + '/' + itemPadre + '=' +  itemId ); // Actualizamos la ruta en consecuencia al nombre
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
