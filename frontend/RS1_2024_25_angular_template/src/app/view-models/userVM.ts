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

export interface GetAllUser {
  userId: number;
  userName: string | null;
}
