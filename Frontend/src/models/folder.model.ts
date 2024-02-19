export interface Folder {
    nombre: string;
    icon: string;
    expanded: boolean;
    childs: Folder[];
    child: Folder;
    seguimientos: Folder[];
    proyectos: Folder[];
    url?: string;

  }