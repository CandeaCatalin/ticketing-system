import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { Ticket } from '../ticket';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.scss']
})
export class TicketListComponent {
  pageTitle = 'Ticket List';
  private _listFilter: string = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
   }
  constructor(private ticketService: TicketService){
    
  }
  tickets: Ticket[] = [];

  ngOnInit(): void {
    this.ticketService.GetTickets().subscribe({
      next: tickets => {
        this.tickets = tickets;
      },
      error: err => console.log(err)
    });
  }
  closeTicket(ticketId:number){
    this.ticketService.closeTicket(ticketId).subscribe({
      next: () => {
        this.tickets = this.tickets.filter(ticket => ticket.id === ticketId);
      },
      error: err => console.log(err)
    });
  }
  deleteTicket(ticketId:number){
    this.ticketService.deleteTicket(ticketId).subscribe({
      next: () => {
        this.tickets = this.tickets.filter(ticket => ticket.id === ticketId);
      },
      error: err => console.log(err)
    });
  }
}
