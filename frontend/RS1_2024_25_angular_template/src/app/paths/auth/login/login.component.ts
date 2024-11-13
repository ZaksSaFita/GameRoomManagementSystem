import {Component} from '@angular/core';
import {AuthService} from '../../../services/auth-services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  username: string = '';
  password: string = '';

  constructor(private authService: AuthService) {
  }

  onSubmit() {
    this.authService.login(this.username, this.password).subscribe(
      response => {
        console.log('Login successful');
      },
      error => {
        console.error('Login failed', error);
      }
    );

  }

}
