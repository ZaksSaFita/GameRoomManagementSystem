import {Component} from '@angular/core';
import {AuthService} from '../../../services/auth-services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrl: './nav-menu.component.css'
})
export class NavMenuComponent {
  isCollapsed: boolean = true;

  constructor(public authService: AuthService) {
  }

  toggleSidebar() {
    this.isCollapsed = !this.isCollapsed;
  }
}
