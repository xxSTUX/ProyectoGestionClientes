import { Component, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { CreaClienteComponent } from "../crea-cliente/crea-cliente.component";
import { CreaProyectoComponent } from "../crea-proyecto/crea-proyecto.component";

@Component({
    selector: 'app-side-menu',
    standalone: true,
    templateUrl: './side-menu.component.html',
    styleUrl: './side-menu.component.css',
    imports: [CreaClienteComponent, CreaProyectoComponent]
})
export class SideMenuComponent {
sidebar: HTMLElement | null = null;
  sidebarOpenBtn: HTMLElement | null = null;
  sidebarCloseBtn: HTMLElement | null = null;
  sidebarLockBtn: HTMLElement | null = null;

  constructor(private elementRef: ElementRef, private router: Router) {}
  onHomeClick() {
    this.router.navigate(['/dashboard']);
  }

  noRedirigir(event: Event) {
    event.preventDefault();
  }

  ngOnInit() {
    this.sidebar = this.elementRef.nativeElement.querySelector(".sidebar");
    this.sidebarOpenBtn = this.elementRef.nativeElement.querySelector("#sidebar-open");
    this.sidebarCloseBtn = this.elementRef.nativeElement.querySelector("#sidebar-close");
    this.sidebarLockBtn = this.elementRef.nativeElement.querySelector("#lock-icon");

    this.addEventListeners();

    if (window.innerWidth < 800 && this.sidebar) {
      this.sidebar.classList.add("close");
      this.sidebar.classList.remove("locked");
      this.sidebar.classList.remove("hoverable");
    }
  }

  toggleLock(): void {
    if (this.sidebar && this.sidebarLockBtn) {
      this.sidebar.classList.toggle("hoverable");

      if (!this.sidebar.classList.contains("hoverable")) {
        this.sidebar.classList.add("locked");
        this.sidebarLockBtn.classList.replace("bi-unlock", "bi-lock-fill");
      } else {
        this.sidebar.classList.remove("locked");
        this.sidebarLockBtn.classList.replace("bi-lock-fill", "bi-unlock");
      }
    }
  }

  hideSidebar(): void {
    if (this.sidebar && this.sidebar.classList.contains("hoverable")) {
      this.sidebar.classList.add("close");
    }
  }

  showSidebar(): void {
    if (this.sidebar && this.sidebar.classList.contains("hoverable")) {
      this.sidebar.classList.remove("close");
    }
  }

  toggleSidebar(): void {
    if (this.sidebar) {
      this.sidebar.classList.toggle("close");
    }
  }

  addEventListeners(): void {
    if (this.sidebarLockBtn) {
      this.sidebarLockBtn.addEventListener("click", () => this.toggleLock());
    }

    if (this.sidebar) {
      this.sidebar.addEventListener("mouseleave", () => this.hideSidebar());
      this.sidebar.addEventListener("mouseenter", () => this.showSidebar());
    }

    if (this.sidebarOpenBtn) {
      this.sidebarOpenBtn.addEventListener("click", () => this.toggleSidebar());
    }

    if (this.sidebarCloseBtn) {
      this.sidebarCloseBtn.addEventListener("click", () => this.toggleSidebar());
    }
  }
}
