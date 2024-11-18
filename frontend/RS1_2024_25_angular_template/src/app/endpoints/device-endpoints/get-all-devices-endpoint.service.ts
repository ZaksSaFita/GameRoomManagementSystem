import {Injectable} from '@angular/core';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {BaseUrl} from '../../helper/BaseUrl';
import {Device} from '../../view-models/deviceVM';


@Injectable({
  providedIn: 'root'
})
export class GetAllDevicesEndpointService implements MyBaseEndpointAsync<void, Device[]> {

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(): Observable<Device[]> {
    return this.httpClient.get<Device[]>(BaseUrl.adress + `devices/getAll`);
  }


}
