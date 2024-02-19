import { Folder } from "./folder.model";

export class elemento implements Folder {
  nombre!: string;
  icon!: string;
  expanded!: boolean;
  childs!: Folder[];
  child!: Folder;
  seguimientos!: Folder[];
  proyectos!: Folder[];
  url?: string | undefined;
  id!: Number;
    
  public elemento(){}
}