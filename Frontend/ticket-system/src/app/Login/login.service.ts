import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginCredentials } from "./LoginCredentials";

@Injectable(
    {
        providedIn: 'root'
    }
) export class LoginService{
    private baseUrl:string = "http://localhost:2004/api/auth";
    constructor(private httpClient:HttpClient){
        
    }
    
    public Login(loginCredentials:LoginCredentials):Observable<any>{
        return this.httpClient.post(this.baseUrl + "/login",loginCredentials);
    }
    public CheckIfLoggedIn():Observable<any>{
    let header = this.CreateHeader();
    return this.httpClient.get(this.baseUrl + "/checkSession",{headers:header});    
    }
    private CreateHeader = ()=>{
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
        return headers;
    }
}