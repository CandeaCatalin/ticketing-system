import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { LoginService } from "./login.service";
import { LoginCredentials } from "./LoginCredentials";

@Component({
    selector: "login-page",
    templateUrl: "./login.component.html",
})
export class LoginComponent {
    PageTitle: string = "Login page";
    error:string = "";
    canSubmit:boolean = false;
    private _loginCredentials: LoginCredentials={email:"", password:""};
    constructor(private loginService: LoginService,private router: Router){}
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
        this.loginService.Login(this.loginCredentials).subscribe({
            next: response => {
                localStorage.setItem("token",response.token);
                this.router.navigate(['home']);
            },
            error: err => {this.error = err.error; console.log(err)}
          });
    }
   }