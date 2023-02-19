import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './Login/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
    constructor(private loginService: LoginService, private router: Router) {
      
    }
    ngOnInit() {
      this.loginService.CheckIfLoggedIn().subscribe({
        next: () => {this.router.navigate(['home']);},
        error: () => {this.router.navigate(['login']);}
      })
    }
}
