export interface Folder {
    nombre: string;
    icon: string;
    expanded: boolean;
    proyectos?: Folder[];
    url?: string;
  }
