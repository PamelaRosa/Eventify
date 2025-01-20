import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../services/event.service';
import { Event } from '../models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  modalRef?: BsModalRef;
  public events: Event[] = [];
  public filteredEvents: Event[] = [];
  public widthImgThumbnail = 50;
  private searchFilterValue: string = '';

  public get searchFilter(): string {
    return this.searchFilterValue;
  }

  public set searchFilter(value: string) {
    this.searchFilterValue = value;
    this.filteredEvents = this.searchFilter
      ? this.filterEvents(this.searchFilter)
      : this.events;
  }

  public filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase().trim();
    return this.events.filter(
      (event) =>
        event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        event.location.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(
    private eventService: EventService,
    private modalService: BsModalService
  ) { }

  public ngOnInit(): void {
    this.getEvents();
  }

  public getEvents(): void {
    this.eventService.getEvents().subscribe(
      {
        next: (events: Event[]) => {
          this.events = events;
          this.filteredEvents = this.events;
        },
        error: (error: any) => {
          console.error('Error retrieving events:', error)
        }
      });
  }

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
