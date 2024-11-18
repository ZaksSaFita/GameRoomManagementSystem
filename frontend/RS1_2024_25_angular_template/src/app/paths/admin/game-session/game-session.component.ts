import {Component, OnInit} from '@angular/core';
import {GetAllUsersResponse} from '../../../view-models/userVM';
import {Device} from '../../../view-models/deviceVM';
import {GetAllUsersEndpointService} from '../../../endpoints/user-endpoints/get-all-users-endpoint.service';
import {
  StartGameSessionEndpointService
} from '../../../endpoints/game-session-endpoints/start-game-session-endpoint.service';
import {GetAllDevicesEndpointService} from '../../../endpoints/device-endpoints/get-all-devices-endpoint.service';
import {StartGameSessionRequest} from '../../../view-models/game-sessionVM';

@Component({
  selector: 'app-game-session',
  templateUrl: './game-session.component.html',
  styleUrl: './game-session.component.css'
})
export class GameSessionComponent implements OnInit {

  devices: Device[] = [];
  users: GetAllUsersResponse[] = [];
  selectedUserId: number = 0;

  constructor(
    private getAllDevicesService: GetAllDevicesEndpointService,
    private startGameSessionService: StartGameSessionEndpointService,
    private getAllUsersService: GetAllUsersEndpointService) {
  }

  ngOnInit() {
    this.getAllDevicesService.handleAsync().subscribe(devices => {
      this.devices = devices;
    });
    this.getAllUsersService.handleAsync().subscribe(users => {
      this.users = users;
      console.log(users);
    });
  }

  startSession(device: Device): void {
    if (!this.selectedUserId) {
      alert("please select a user");
    }
    const request: StartGameSessionRequest = {
      userId: this.selectedUserId,
      deviceId: device.deviceId
    };

    this.startGameSessionService.handleAsync(request).subscribe(result => {
      console.log("Game-session started", result);
    })
  }

}
