import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { NestedTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatNestedTreeNode, MatTreeModule, MatTreeNestedDataSource} from '@angular/material/tree';
import { MatProgressBarModule} from '@angular/material/progress-bar';
import { Folder } from '../../models/folder.model';
import { FolderService } from '../services/folder.service';

@Component({
  selector: 'app-tree-menu',
  standalone: true,
  imports: [MatIconModule, MatNestedTreeNode,MatButtonModule, MatProgressBarModule, MatTreeModule],
  templateUrl: './tree-menu.component.html',
  styleUrl: './tree-menu.component.css'
})
export class TreeMenuComponent {
  treeControl = new NestedTreeControl<Folder>(node => node.child);  
  dataSource = new MatTreeNestedDataSource<Folder>();   
  
  constructor(private folderService: FolderService) {} 

  ngOnInit() {
    this.folderService.getFolders().subscribe(data => {
      this.dataSource.data = data;
    });
  }
  
  hasChild = (_: number, node: Folder) => !!node.child && node.child.length > 0;  
}  