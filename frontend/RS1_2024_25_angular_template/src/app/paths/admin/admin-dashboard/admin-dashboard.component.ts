import {Component, OnInit} from '@angular/core';
import {
  GetAllUsersEndpointService,
  GetAllUsersResponse
} from '../../../endpoints/user-endpoints/get-all-users-endpoint.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent implements OnInit {

  users: GetAllUsersResponse[] = [];

  constructor(private GetAllUsersService: GetAllUsersEndpointService) {
  }

  ngOnInit() {
    this.GetAllUsersService.handleAsync().subscribe(data => this.users = data.slice(-5).sort((a, b) => b.userId - a.userId));
  }


}
