import { Component } from '@angular/core';

@Component({
  selector: 'app-tree-menu',
  standalone: true,
  imports: [],
  templateUrl: './tree-menu.component.html',
  styleUrl: './tree-menu.component.css'
})
export class TreeMenuComponent {
  displayTree: any[] = [];
  selectedNode: any;

  constructor() {
    this.buildEmptyTree();
  }

  showNode(data: any) {
    return data.name;
  }

  isClient(selectedNode: any) {
    if (selectedNode == undefined) {
      return false;
    }

    if (selectedNode.device_name != undefined) {
      return true;
    }

    return false;
  }

  buildEmptyTree() {
    this.displayTree = [
      {
        name: 'Root',
        type_name: 'Node',
        show: true,
        nodes: [
          {
            name: 'Loose',
            group_name: 'Node-1',
            show: true,
            nodes: [
              {
                name: 'Node-1-1',
                device_name: 'Node-1-1',
                show: true,
                nodes: [],
              },
              {
                name: 'Node-1-2',
                device_name: 'Node-1-2',
                show: true,
                nodes: [],
              },
              {
                name: 'Node-1-3',
                device_name: 'Node-1-3',
                show: true,
                nodes: [],
              },
            ],
          },
          {
            name: 'God',
            group_name: 'Node-2',
            show: true,
            nodes: [
              {
                name: 'Vadar',
                device_name: 'Node-2-1',
                show: true,
                nodes: [],
              },
            ],
          },
          {
            name: 'Borg',
            group_name: 'Node-3',
            show: true,
            nodes: [],
          },
          {
            name: 'Fess',
            group_name: 'Node-4',
            show: true,
            nodes: [],
          },
        ],
      },
    ];
    [
      {
        name: 'Android',
        type_name: 'Android',
        icon: 'icon-android icon-3',
        show: true,
        nodes: [],
      },
    ];
  }
}
