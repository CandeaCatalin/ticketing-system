import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Ticket } from '../ticket';
import { TicketService } from '../ticket.service';
import { EditTicketModel } from './editTicketModel';

@Component({
  selector: 'app-edit-ticket',
  templateUrl: './edit-ticket.component.html',
  styleUrls: ['./edit-ticket.component.scss']
})
export class EditTicketComponent {
  constructor(private router: Router, private ticketService: TicketService) {}
  ticket!:Ticket;
  newTicket!:Ticket;
  pageTitle:string = 'Edit Ticket';
  ngOnInit() {
    this.ticket = this.ticketService.getEditedTicket();
    this.newTicket = this.ticket;
  }
  editTicket(){
    const editedTicketByModel:EditTicketModel = 
    {
      id:this.newTicket.id,
      ticketTypeId:this.newTicket.ticketType.id,
      subject:this.newTicket.subject,
      description:this.newTicket.description,
      customerName:this.newTicket.customerName,
      serviceTypeId:this.newTicket.serviceType.id,
      statusId:this.newTicket.status.id,
      priorityId:this.newTicket.priority.id};
    this.ticketService.editTicket(editedTicketByModel).subscribe({
      next: response => {
        this.router.navigate(["home"]);
      },
      error: err => console.log(err)
    });;
  }
}
