import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: any = [];
  public filteredEvents: any = [];
  widthImgThumbnail = 50;
  private _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.filteredEvents = this.filterList
      ? this.filterEvents(this.filterList)
      : this.events;
  }

  filterEvents(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase().trim();
    return this.events.filter(
      (event: any) =>
        event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        event.location.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.getEvents();
  }

  public getEvents(): void {
    this.eventService.getEvent().subscribe(
      response => {
        this.events = response;
        this.filteredEvents = this.events;
      },
      (error) => console.error('Error retrieving events:', error)
    );
  }
}
