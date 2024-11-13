import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {BaseUrl} from '../../helper/BaseUrl';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string | null = null;

  constructor(private http: HttpClient, private router: Router) {
  }

  login(username: string, password: string): Observable<{ token: string, role: string }> {
    return this.http.post<{ token: string, role: string }>(BaseUrl.adress + 'auth/login', {username, password})
      .pipe(
        tap(response => {
          this.token = response.token;
          localStorage.setItem('token', response.token);
          localStorage.setItem('role', response.role);
          console.log(response.role, "ovo je role");
          this.redirectUser(response.role);
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

  getRole(): string | null {
    return localStorage.getItem('role');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  private redirectUser(role: string) {
    {

      if (role === 'Admin') {
        this.router.navigate(['/admin']);
      } else if (role === 'Employee') {
        this.router.navigate(['/employee']);
      } else if (role === 'User') {
        this.router.navigate(['/user']);
      }
    }
    console.log('Redirecting user with role:', role);
  }
}
