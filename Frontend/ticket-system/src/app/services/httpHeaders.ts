import { HttpHeaders } from "@angular/common/http";

export const CreateHeader = ()=>{
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    return headers;
}