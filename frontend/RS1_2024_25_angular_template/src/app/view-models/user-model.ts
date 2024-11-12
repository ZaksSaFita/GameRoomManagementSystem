export interface User {
  id: number;
  username: string;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  imageUrl: string | null;
  ratingPoints: number;
  level: number;
  experiencePoints: number;
  credits: number;
  isAdmin: boolean;
  isManager: boolean;
  isUser: boolean;
  cityId: number;
  cityName: string;
}


export interface AllUser {
  users: User[];
}
