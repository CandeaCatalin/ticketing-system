import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { AuthService } from "../services/auth/auth.service";
import { LoginCredentials } from "./loginCredentials";

@Component({
    selector: "login-page",
    templateUrl: "./login.component.html",
})
export class LoginComponent {
    pageTitle: string = "Login page";
    error:string = "";
    canSubmit:boolean = false;
    private _loginCredentials: LoginCredentials={email:"", password:""};
    constructor(private authService: AuthService,private router: Router, private jwtService:JwtHelperService){}
    get loginCredentials(){
        return this._loginCredentials;
    }
    set loginCredentials(value: LoginCredentials){
        this._loginCredentials = value;
        if(this._loginCredentials.email === "" || this._loginCredentials.password === ""){
            this.canSubmit = false;
        }else{
            this.canSubmit = true;
        }
    }
    submit(){
        this.authService.Login(this.loginCredentials).subscribe({
            next: response => {
                localStorage.setItem("token",response.token);
                localStorage.setItem("name",this.jwtService.decodeToken(response.token).unique_name);
                this.router.navigate(['home']);
            },
            error: err => {this.error = err.error;}
          });
    }
}