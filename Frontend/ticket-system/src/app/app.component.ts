import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
    constructor(private loginService: AuthService, private router: Router) {
      
    }
    ngOnInit() {
      this.loginService.CheckIfLoggedIn().subscribe({
        next: () => {
          this.router.navigate(['home']);
          
        },
        error: () => {this.router.navigate(['login']);}
      })
    }
}
