import {Injectable} from '@angular/core';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {HttpClient} from '@angular/common/http';
import {BaseUrl} from '../../helper/BaseUrl';

export interface GetAllUsersResponse {
  userId: number;
  firstName: string | null;
  lastName: string | null;
  username: string | null;
  email: string | null;
  phoneNumber: string | null;
  cityName: string | null;
  countryName: string | null;
  roleName: string | null;
}


@Injectable({
  providedIn: 'root'
})
export class GetAllUsersEndpointService implements MyBaseEndpointAsync<void, GetAllUsersResponse[]> {

  constructor(private htttpClient: HttpClient) {
  }

  handleAsync() {
    return this.htttpClient.get<GetAllUsersResponse[]>(BaseUrl.adress + `user/getAll`);
  }

}
