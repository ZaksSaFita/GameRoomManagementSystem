import {Component, OnInit} from '@angular/core';
import {User} from '../../../view-models/user-model';
import {UserGetallEndpointService} from '../../../endpoints/user-endpoints/user-getall-endpoint.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  visible: boolean = false;
  users: User[] = [];

  constructor(private userGetallservice: UserGetallEndpointService) {
  }

  ngOnInit(): void {
    this.loadAllUsers();
  }


  isVisible() {
    this.visible = !this.visible;
  }

  private loadAllUsers(): void {
    this.userGetallservice.handleAsync().subscribe({
      next: (data) => {
        this.users = data.users;
      },
      error: (error) => console.error('Error loading users', error)
    })
  }
}
