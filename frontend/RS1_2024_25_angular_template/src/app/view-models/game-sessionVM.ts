export interface GameSession {
  gameSessionId: number;
  userId: number;
  deviceId: number;
  startTime: Date;
  duration: number;
  actualPlayTime: number;
}

export interface StartGameSessionRequest {
  userId: number;
  deviceId: number;
}

export interface EndGameSessionRequest {
  gameSessionId: number;
}
