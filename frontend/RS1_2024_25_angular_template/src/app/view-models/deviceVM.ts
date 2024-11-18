export interface Device {
  deviceId: number;
  deviceType: string;
  isAvailable: boolean;
  currentUserId?: number;
  startTime?: Date;
  maxPlayTime?: number;
}

export interface DeviceStatus {
  deviceId: number;
  deviceType: string;
  isAvailable: boolean;
  currentUserId?: number;
  startTime?: Date;
  maxPlayTime?: number;
}
