import {Component, OnInit} from '@angular/core';
import {
  GetAllUsersEndpointService,
  GetAllUsersResponse
} from '../../../endpoints/user-endpoints/get-all-users-endpoint.service';
import {AuthService} from '../../../services/auth-services/auth.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent implements OnInit {
  isCollapsed = true;
  users: GetAllUsersResponse[] = [];
  loggedUser: any = null;

  constructor(private GetAllUsersService: GetAllUsersEndpointService, private auth: AuthService) {
  }

  ngOnInit() {
    this.loadUsers();
    this.getLoggedInUser();
  }

  loadUsers() {
    this.GetAllUsersService.handleAsync().subscribe(data =>
      this.users = data.slice(-10).sort((a, b) => b.userId - a.userId));
  }

  getLoggedInUser() {
    this.loggedUser = this.auth.getUserInfoFromToken();
    console.log("userinfo: ", this.loggedUser);
  }

  toggleSidebar() {
    this.isCollapsed = !this.isCollapsed;
  }
}
