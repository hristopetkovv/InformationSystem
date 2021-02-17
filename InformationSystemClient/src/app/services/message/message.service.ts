import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MessageModel } from 'src/app/models/message/message.model';
import { MesageSearchDto } from 'src/app/models/search/message-search.dto';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private http: HttpClient) { }

  getMessages(): Observable<MessageModel[]> {
    return this.http.get<MessageModel[]>(`api/message`);
  }

  getMessagesByFilter(filter: MesageSearchDto): Observable<any[]> {
    return this.http.get<any[]>(`api/message/filter${filter.getQueryString()}`);
  }

  getMessageById(id: number): Observable<MessageModel> {
    return this.http.get<MessageModel>(`api/message/${id}`);
  }

  addMessage(message: MessageModel): Observable<MessageModel[]> {
    return this.http.post<MessageModel[]>(`api/message`, message);
  }

  updateMessage(id: number, message: MessageModel): Observable<any> {
    return this.http.put(`api/message/${id}`, message);
  }

  updateMessageStatus(id: number, status: number): Observable<any> {
    return this.http.put(`api/message/status/${id}`, status);
  }

}
