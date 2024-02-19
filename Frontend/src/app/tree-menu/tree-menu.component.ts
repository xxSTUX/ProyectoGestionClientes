import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatNestedTreeNode, MatTreeModule, MatTreeNestedDataSource} from '@angular/material/tree';
import { MatProgressBarModule} from '@angular/material/progress-bar';
import { Folder } from '../../models/folder.model';
import { FolderService } from '../services/folder.service';
import { Router } from '@angular/router';
import { elemento } from '../../models/elemento.model';

@Component({
  selector: 'app-tree-menu',
  standalone: true,
  imports: [MatIconModule, MatNestedTreeNode,MatButtonModule, MatProgressBarModule, MatTreeModule],
  templateUrl: './tree-menu.component.html',
  styleUrl: './tree-menu.component.css',
})
export class TreeMenuComponent {
  treeControl = new NestedTreeControl<Folder>(node => node.childs);  
  dataSource = new MatTreeNestedDataSource<Folder>();   
  
  constructor(private folderService: FolderService, private router: Router) {} 

  ngOnInit() {
    this.folderService.getFolders().subscribe(data => {
      data = this.recarga(data);
      this.dataSource.data = data;
      alert(data)
    });
  }
  recarga(clientes: Folder[]){
    var pos = 0
    clientes.forEach(cliente => {
      var aux = new elemento();
      cliente.proyectos.forEach(proyecto => {
        
        var seguimientos = new elemento();
        seguimientos.nombre = "Seguimientos"
        seguimientos.childs = proyecto.seguimientos;
        console.log(seguimientos.childs.length)
        if(seguimientos.childs.length > 0){
          aux.childs = [seguimientos as unknown as Folder];    
          proyecto.childs = aux.childs
        }
        
        
      }); 

      if(aux.childs === undefined){
        cliente.childs = cliente.proyectos.concat(cliente.seguimientos)
      }else{
        var proyecto = new elemento();
        proyecto.nombre = "Proyectos"
        var seguimientos = new elemento();
        seguimientos.nombre = "Seguimientos"
        proyecto.childs = cliente.proyectos;
        seguimientos.childs = cliente.seguimientos;
        aux.childs = [proyecto as unknown as Folder,seguimientos as unknown as Folder];
        cliente.childs = aux.childs;
      }
      if (cliente.nombre === "Hiberus") {
        cliente.nombre = "Proyectos"
      }
      
    });
    
    return clientes
  }
  
  hasChild = (_: number, node: Folder) => !!node.childs && node.childs.length > 0;  
  hasNoChild = (_: number, node: Folder) => !this.hasChild(_, node);

  onNodeClick(node: Folder) {
    if (node.nombre) {
      this.router.navigate(['/dashboard'], { fragment: node.nombre });
    } else {
      this.router.navigate(['/error']);
    }
  }
}  
