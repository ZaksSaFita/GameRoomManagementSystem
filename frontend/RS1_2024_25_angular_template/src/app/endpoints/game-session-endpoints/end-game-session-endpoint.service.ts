import {Injectable} from '@angular/core';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {HttpClient} from '@angular/common/http';
import {BaseUrl} from '../../helper/BaseUrl';
import {Observable} from 'rxjs';
import {EndGameSessionRequest, GameSession} from '../../view-models/game-sessionVM';


@Injectable({
  providedIn: 'root'
})
export class EndGameSessionEndpointService implements MyBaseEndpointAsync<EndGameSessionRequest, GameSession> {

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: EndGameSessionRequest): Observable<GameSession> {
    return this.httpClient.post<GameSession>(`${BaseUrl.adress}/gamesession/end`, request);
  }
}
