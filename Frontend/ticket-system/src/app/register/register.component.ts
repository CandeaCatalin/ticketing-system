import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';
import { RegisterCredentials } from './registerCredentials';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  pageTitle: string = "Register page";
  error:string = "";
  canSubmit:boolean = false;
  private _registerCredentials:RegisterCredentials = {email: "", password: "", firstName: "", lastName: "", confirmPassword:""};
  get registerCredentials(){
    return this._registerCredentials;
}
set registerCredentials(value: RegisterCredentials){
    this._registerCredentials = value;
    if(this._registerCredentials.email === "" || this._registerCredentials.password === ""){
        this.canSubmit = false;
    }else{
        this.canSubmit = true;
    }
}
  constructor(private authService: AuthService,private router: Router){}
  submit(){
    if(!this.checkPassword()){
      this.authService.Register(this.registerCredentials).subscribe({
        next: response => {
              this.router.navigate(['login']);
        },
        error: err => {this.error = err.error.exception;}
      });
    }else{
      this.error = "Passwords does not match";
    }
    
  }
  checkPassword(){
    return this.registerCredentials.confirmPassword !== this.registerCredentials.password;
  }
}