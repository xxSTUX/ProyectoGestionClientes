import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-tree-menu-dinamico',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './tree-menu-dinamico.component.html',
  styleUrl: './tree-menu-dinamico.component.css'
})
export class TreeMenuDinamicoComponent {
  data: { [key: string]: Object }[] = [];
  clienteData: { [key: string]: Object }[] = [];
  public nodoAbierto = 0;

  constructor(private http: HttpClient, private location: Location, private router: Router) { }

  ngOnInit() {
    this.getMethod();
  }

  public actualizarArbol(){
    const treeviewElement = document.getElementById("treeview");
        if (treeviewElement) {
            treeviewElement.innerHTML = "";
            this.renderBootstrapTreeView(this.data, treeviewElement);
        }
  }

  public getJsonValue: any;
  public getJsonValueCliente: any;

  public getMethod() {
    this.http.get("https://localhost:7075/api/cliente/Basic").subscribe((data: any) => {
      this.getJsonValue = data;
      console.log(data);

      //Para el proximo día tengo que hacer los bucles y la logica correspondiente para la carga dinamica del arbol.
      for (let i = 0; i < this.getJsonValue.length; i++) {
        let clienteId = this.getJsonValue[i].clienteId;
        this.data.push({nodeId: "Cliente " + clienteId + " " + i, nodeText: this.getJsonValue[i].nombre, nodeChild: [{ nodeId: clienteId +" Proyectos", nodeText: 'Proyectos', nodeChild: []  },
                                                                                                          { nodeId:  clienteId + " Seguimientos", nodeText: 'Seguimientos', nodeChild: [] },
                                                                                                          { nodeId:  clienteId +" Licitaciones", nodeText: 'Licitaciones', nodeChild: []}]
      });
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
      //this.location.go(this.location.path() + '#' + item.nodeText);//Cambio de la ruta mostrada
      const listItem = document.createElement("li");
      listItem.classList.add("list-group-item");
      const icon = document.createElement("i");
      
      if (!parentNode) {//Si el nodo no tiene padre, la ruta la cambia al nombre del nodo (lo guardo en el campo textContent para poder utilizarlo luego)
        item.textContent ="Cliente#" + item.nodeText; //Cambiar posteriormente el # por un / cuando hagamos la logica de los otros componentes.
      }
      else{ //Si 
        item.textContent = parentNode.textContent + "#" + item.nodeText; // Concatenar el nombre del padre a la ruta. Cambiar cuando hagamos la logica el # por un /
      }

        icon.addEventListener('click', (event) => {
          if((item.nodeId.split(" ")[0] == "Cliente")){
            event.stopPropagation();
            let dataIndex = item.nodeId.split(" ")[2]
            
            this.http.get("https://localhost:7075/api/cliente/Basic/Completo/"+ item.nodeId.split(" ")[1]).subscribe((clienteData: any) => { //Id del cliente --> item.nodeId.split(" ")[1]
            this.getJsonValueCliente = clienteData;
            console.log(this.getJsonValueCliente);
            // console.log(this.data);
             console.log(this.getJsonValueCliente.nombre);
            // console.log(this.getJsonValueCliente.clienteId);
            item.nodeId = item.nodeId.replace(/\s/g, ',');
            for(let i = 0; i < this.getJsonValueCliente.proyectos.length;i++){//Proyectos
              let seguimientosProyecto = [];
              let licitacionesProyecto = [];
              for (let j = 0; j < this.getJsonValueCliente.proyectos[i].seguimientos.length;j++){ //Recorre seguimientos de un proyecto
                seguimientosProyecto.push({nodeId:"Seguimiento " + this.getJsonValueCliente.proyectos[i].seguimientos[j].seguimientoId,nodeText:this.getJsonValueCliente.proyectos[i].seguimientos[j].nombre})
              }
              for(let j = 0; j < this.getJsonValueCliente.proyectos[i].licitaciones.length;j++){//Recorre licitaciones de un proyecto
                licitacionesProyecto.push({nodeId:"Licitacion " + this.getJsonValueCliente.proyectos[i].licitaciones[j].licitacionId,nodeText:this.getJsonValueCliente.proyectos[i].licitaciones[j].nombre})
              }
              data[dataIndex].nodeChild[0].nodeChild.push({nodeId: "Proyecto " + this.getJsonValueCliente.proyectos[i].proyectoId, nodeText: this.getJsonValueCliente.proyectos[i].nombre, nodeChild: [{nodeId: "Seguimientos " + this.getJsonValueCliente.proyectos[i].proyectoId, nodeText: "Seguimientos",nodeChild:seguimientosProyecto},
                                                                                                                                                                                                                                    {nodeId: "Licitaciones " + this.getJsonValueCliente.proyectos[i].proyectoId, nodeText: "Licitaciones",nodeChild:licitacionesProyecto}]});
            }
            for(let i = 0; i < this.getJsonValueCliente.seguimientos.length;i++){//Seguimientos
              data[dataIndex].nodeChild[1].nodeChild.push({nodeId: "Seguimiento " + this.getJsonValueCliente.seguimientos[i].seguimientoId, nodeText: this.getJsonValueCliente.seguimientos[i].nombre/*, nodeChild: []*/});
            }
            for(let i = 0; i < this.getJsonValueCliente.licitaciones.length;i++){//Licitaciones
              data[dataIndex].nodeChild[2].nodeChild.push({nodeId: "Licitacion " + this.getJsonValueCliente.licitaciones[i].licitacionId, nodeText: this.getJsonValueCliente.licitaciones[i].nombre/*, nodeChild: []*/});
            }
          
            console.log(this.data);
            this.actualizarArbol();
          });
          } 
        });
      
      if ((item.nodeChild && item.nodeChild.length > 0)) { //Caso en el que se añade el icono de + //  Posible logica || (item.nodeId.split(" ")[0] == "Cliente")
        
        icon.classList.add("bi", "bi-plus-circle", "me-2"); // Icono de 'plus' de Bootstrap
      } else {
        // Si el nodo no tiene hijos, añadir el evento click para el enrutamiento
        //listItem
        listItem.addEventListener('click', (event) => {
          event.stopPropagation();
          // Obtener el padre
          this.location.go(this.location.path() + '#' + parentNode.nodeText + '=' + item.nodeId);//Cambio de la ruta mostrada, mostrar la del padre del item TODO-Gian quitar a aprtir del = en la fragmet para tratar el componente mostrado
          const newPath = this.location.path() + '#' + parentNode.nodeText + '=' + item.nodeId;//conseguir la ruta padre del item + el id del elemento clickado
          // Aquí puedes añadir la lógica para mostrar el nuevo componente
          alert(item.nodeId);
          console.log('ID del nodo clicado:', item.nodeId);


          // Obtener el padre del nodo que ya no tiene mas hijos, el elemento padre del que depende el item que tiene el evento de click
          if (parentNode) {
            console.log('El padre del nodo sin hijos es:', parentNode.nodeText);
          }
          this.router.navigateByUrl(newPath);//Provocar un navigationEnd para que se actualice el div dinamico que muestra un componente u otro
        });
      }
      listItem.appendChild(icon);
      const textSpan = document.createElement("span");
      textSpan.textContent = item.nodeText;
      

      textSpan.addEventListener('click', (event) => { //Para poder clicar en el texto de un nodo y que cambie la ruta, independientemente de si es hijo o no
        event.stopPropagation();
      
        const newPath = window.location.pathname + '#' + item.textContent; // Cambiamos la ruta parentNode.Text + "/" +
        window.location.href = newPath; // Actualizamos la ruta en consecuencia al nombre
        
        console.log(newPath.split("Cliente/"));
      }); //Hasta aqui 

      listItem.appendChild(icon);
      listItem.appendChild(textSpan);

      if ((item.nodeChild && item.nodeChild.length > 0) && item.nodeId.split(" ")[0] != "Cliente") {
        // Añadir evento click para cambiar el ícono y colapsar/expandir elementos hijos
        //listItem
        icon.addEventListener('click', (event) => {
          if(item.nodeId.split(" ")[0] != "Cliente"){
          event.stopPropagation();
          if (icon.classList.contains('bi-plus-circle')) { //Si tiene un botón +
            icon.classList.replace('bi-plus-circle', 'bi-dash-circle');
          } else {
            icon.classList.replace('bi-dash-circle', 'bi-plus-circle');
          }

          sublist.style.display = sublist.style.display === 'none' ? '' : 'none';}
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

