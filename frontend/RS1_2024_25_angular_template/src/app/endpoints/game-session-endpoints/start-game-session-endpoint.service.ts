import {Injectable} from '@angular/core';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {HttpClient} from '@angular/common/http';
import {BaseUrl} from '../../helper/BaseUrl';
import {Observable} from 'rxjs';
import {GameSession, StartGameSessionRequest} from '../../view-models/game-sessionVM';


@Injectable({
  providedIn: 'root'
})
export class StartGameSessionEndpointService implements MyBaseEndpointAsync<StartGameSessionRequest, GameSession> {

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: StartGameSessionRequest): Observable<GameSession> {
    return this.httpClient.post<GameSession>(BaseUrl.adress + `gamesession/start`, request);
  }
}
