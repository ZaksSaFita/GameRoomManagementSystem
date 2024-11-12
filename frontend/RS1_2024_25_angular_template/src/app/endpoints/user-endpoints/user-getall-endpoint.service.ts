import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {AllUser} from '../../view-models/user-model';
import {BaseUrl} from '../../helper/BaseUrl';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserGetallEndpointService implements MyBaseEndpointAsync<void, AllUser> {

  constructor(private http: HttpClient) {
  }

  handleAsync(): Observable<AllUser> {
    return this.http.get<AllUser>(BaseUrl.adress + `user/all`);
  }

}


