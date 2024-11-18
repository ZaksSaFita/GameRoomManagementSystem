import {Injectable} from '@angular/core';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {HttpClient} from '@angular/common/http';
import {BaseUrl} from '../../helper/BaseUrl';
import {GetAllUser, GetAllUsersResponse} from '../../view-models/userVM';


@Injectable({
  providedIn: 'root'
})
export class GetAllUsersEndpointService implements MyBaseEndpointAsync<void, GetAllUsersResponse[]> {

  constructor(private httpClient: HttpClient) {
  }

  handleAsync() {
    return this.httpClient.get<GetAllUsersResponse[]>(BaseUrl.adress + `user/getAll`);
  }

  getAllUsers() {
    return this.httpClient.get<GetAllUser[]>(BaseUrl.adress + `user/getAll`);
  }

}
