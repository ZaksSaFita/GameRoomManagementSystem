import {Component, OnInit} from '@angular/core';
import {Device} from '../../../view-models/deviceVM';
import {GetAllDevicesEndpointService} from '../../../endpoints/device-endpoints/get-all-devices-endpoint.service';
import {
  StartGameSessionEndpointService
} from '../../../endpoints/game-session-endpoints/start-game-session-endpoint.service';
import {StartGameSessionRequest} from '../../../view-models/game-sessionVM';
import {GetAllUsersResponse} from '../../../view-models/userVM';
import {GetAllUsersEndpointService} from '../../../endpoints/user-endpoints/get-all-users-endpoint.service';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrl: './device-list.component.css'
})
export class DeviceListComponent implements OnInit {

  devices: Device[] = [];
  users: GetAllUsersResponse[] = [];
  selectedUserId: number | null = null;

  constructor(private getAllUsersService: GetAllUsersEndpointService, private getAllDevicesService: GetAllDevicesEndpointService, private startGameSessionService: StartGameSessionEndpointService) {
  }

  ngOnInit(): void {
    this.getAllDevicesService.handleAsync().subscribe(devices => {
      this.devices = devices;
    });
    this.getAllUsersService.handleAsync().subscribe(users => {
      this.users = users;
    });
  }

  startSession(device: Device): void {
    if (!this.selectedUserId) {
      alert("please select a user");
      return;
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
