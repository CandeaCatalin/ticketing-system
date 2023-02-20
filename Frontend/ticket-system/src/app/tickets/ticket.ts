import { TicketPriority } from "./TicketPriority";
import { TicketStatus } from "./TicketStatus";
import { TicketServiceType } from "./TicketServiceType";
import { TicketType } from "./TicketType";

export type Ticket = {
    id: number,
    ticketType: TicketType,
    serviceType:TicketServiceType,
    subject: string,
    description:string,
    status: TicketStatus,
    opened: Date,
    customerName:string,
    closed: Date,
    priority: TicketPriority,
}