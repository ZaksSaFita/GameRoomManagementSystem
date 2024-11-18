import {Injectable} from '@angular/core';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {DeviceStatus} from '../../view-models/deviceVM';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {BaseUrl} from '../../helper/BaseUrl';

@Injectable({
  providedIn: 'root'
})
export class GetDeviceStatusEndpointService implements MyBaseEndpointAsync<void, DeviceStatus[]> {

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(): Observable<DeviceStatus[]> {
    return this.httpClient.get<DeviceStatus[]>(BaseUrl.adress + `devices/status`);
  }
}
