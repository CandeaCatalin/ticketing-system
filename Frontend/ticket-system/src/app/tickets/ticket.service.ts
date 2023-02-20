import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CreateHeader } from "../services/httpHeaders";
import { CreateTicketModel } from "./create-ticket/CreateTicketModel";

@Injectable(
    {
        providedIn: 'root'
    }
) export class TicketService{
    private baseUrl:string = "http://localhost:3004/api/Ticket";
    constructor(private httpClient:HttpClient){
        
    }
    
    public GetTickets():Observable<any>{
        let header = CreateHeader();
        return this.httpClient.get(this.baseUrl,{headers:header} );
    }
    public GetStandardProperties():Observable<any>{
        let header = CreateHeader();
        return this.httpClient.get(this.baseUrl +"/getStandardProperties",{headers:header} );
    }
    public createTicket(createdTicket:CreateTicketModel):Observable<any>
    {
        let header = CreateHeader();
        return this.httpClient.post(this.baseUrl +"/create",createdTicket,{headers:header} );
    }
    public deleteTicket(ticketId:number):Observable<any>{
        let header = CreateHeader();
        return this.httpClient.delete(this.baseUrl +"/delete",{headers:header, body:{id:ticketId}});
    }
    public closeTicket(ticketId:number):Observable<any>{
        let header = CreateHeader();
        return this.httpClient.post(this.baseUrl +"/close",{id:ticketId},{headers:header});
    }
}