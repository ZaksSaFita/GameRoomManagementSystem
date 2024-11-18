import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {BaseUrl} from '../../helper/BaseUrl';
import {jwtDecode} from 'jwt-decode';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string | null = null;

  constructor(private http: HttpClient, private router: Router) {
  }

  login(username: string, password: string): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(BaseUrl.adress + 'auth/login', {username, password})
      .pipe(
        tap(response => {
          this.token = response.token;
          localStorage.setItem('token', response.token);

          //decode user token
          const userInfo = this.getUserInfoFromToken();
          console.log("userRole", userInfo.role);

          this.redirectUser(userInfo.role);
          if (userInfo) {
            console.log("userID", userInfo.nameid);
            console.log("userRole", userInfo.role);

          }


          //to fatch by id implement this
          //this.fetchUserDetails(userInfo.id);
        })
      );
  }

  logout() {
    this.token = null;
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    this.router.navigate(['/']);
  }

  isAuthenticated(): boolean {
    return this.token !== null || localStorage.getItem('token') !== null;
  }


  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getUserInfoFromToken(): any {
    const token = this.getToken();
    if (token) {
      try {
        return jwtDecode(token);
      } catch (error) {
        console.error('Invalid token:', error);
        return null;
      }
    }
    return null;
  }


  private redirectUser(role: string) {
    {

      if (role == 'Admin') {
        this.router.navigate(['/admin']);
      } else if (role === 'Employee') {
        this.router.navigate(['/admin']);
      } else if (role === 'User') {
        this.router.navigate(['/public']);
      }
    }
    console.log('Redirecting user with role:', role);
  }


}
