import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TicketService } from '../ticket.service';
import { CreateTicketModel } from './createTicketModel';

@Component({
  selector: 'app-create-ticket',
  templateUrl: './create-ticket.component.html',
  styleUrls: ['./create-ticket.component.scss']
})
export class CreateTicketComponent {
  pageTitle = 'Create Ticket';
  createdTicket : CreateTicketModel ={subject: "",description:"",customerName:"",ticketTypeId:0,statusId:0,priorityId:0,serviceTypeId:0,userName:localStorage.getItem("name") as string};
  standardTicketProperties: any;
  constructor(private ticketService:TicketService, private router:Router){}
  createTicket(){
    this.ticketService.createTicket(this.createdTicket).subscribe({
      next: response => {
        this.router.navigate(["home"]);
      },
      error: err => console.log(err)
    });;
  }
  ngOnInit(){
    this.ticketService.GetStandardProperties().subscribe({
      next: standardProperties => {
        this.standardTicketProperties = standardProperties;
      },
      error: err => console.log(err)
    });
  }
}
