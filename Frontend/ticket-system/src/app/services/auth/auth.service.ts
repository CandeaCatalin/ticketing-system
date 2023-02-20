import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginCredentials } from "../../login/loginCredentials";
import { RegisterCredentials } from "../../register/registerCredentials";
import { CreateHeader } from "../httpHeaders";

@Injectable(
    {
        providedIn: 'root'
    }
) export class AuthService{
    private baseUrl:string = "http://localhost:2004/api/auth";
    constructor(private httpClient:HttpClient){
        
    }
    
    public Login(loginCredentials:LoginCredentials):Observable<any>{
        return this.httpClient.post(this.baseUrl + "/login",loginCredentials);
    }
    public CheckIfLoggedIn():Observable<any>{
    let header = CreateHeader();
    return this.httpClient.get(this.baseUrl + "/checkSession",{headers:header});    
    }
    public Register(registerCredentials:RegisterCredentials):Observable<any>{
        return this.httpClient.post(this.baseUrl + "/register",registerCredentials);
    }
}