import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatNestedTreeNode, MatTreeModule, MatTreeNestedDataSource} from '@angular/material/tree';
import { MatProgressBarModule} from '@angular/material/progress-bar';
import { Folder } from '../../models/folder.model';
import { FolderService } from '../services/folder.service';
import { TabmenuComponent } from '../tabmenu/tabmenu.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tree-menu',
  standalone: true,
  imports: [MatIconModule, MatNestedTreeNode,MatButtonModule, MatProgressBarModule, MatTreeModule, TabmenuComponent],
  templateUrl: './tree-menu.component.html',
  styleUrl: './tree-menu.component.css',
})
export class TreeMenuComponent {
  treeControl = new NestedTreeControl<Folder>(node => node.proyectos);
  dataSource = new MatTreeNestedDataSource<Folder>();

  constructor(private folderService: FolderService, private router: Router) {}

  ngOnInit() {
    this.folderService.getFolders().subscribe(data => {
      this.dataSource.data = data;
    });
  }

  hasChild = (_: number, node: Folder) => !!node.proyectos && node.proyectos.length > 0;
  hasNoChild = (_: number, node: Folder) => !this.hasChild(_, node);

  onNodeClick(node: Folder) {
    if (node.nombre) {
      this.router.navigate(['/dashboard'], { fragment: node.nombre });
    } else {
      this.router.navigate(['/error']);
    }
  }
}
