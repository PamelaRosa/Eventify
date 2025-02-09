import { Event } from './../models/Event';

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class EventService {
  baseURL = "https://localhost:5001/api/Events";

  constructor(private http: HttpClient) { }


  public getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseURL);
  }

  public getEventsByTheme(theme: string): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.baseURL}/theme/${theme}`);
  }

  public getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(`${this.baseURL}/${id}`);
  }
}
