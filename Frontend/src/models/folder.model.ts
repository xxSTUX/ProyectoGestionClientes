export interface Folder {
    name: string;
    icon: string;
    expanded: boolean;
    child?: Folder[];
    url?: string;
  }