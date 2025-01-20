import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventService } from 'src/app/services/event.service';
import { Event } from 'src/app/models/Event';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  // Modal
  modalRef?: BsModalRef;

  // Properties
  public events: Event[] = [];
  public filteredEvents: Event[] = [];
  public widthImgThumbnail = 50;

  // Search filter
  private searchFilterValue: string = '';

  // Accessor for search filter
  public get searchFilter(): string {
    return this.searchFilterValue;
  }

  public set searchFilter(value: string) {
    this.searchFilterValue = value;
    this.filteredEvents = this.searchFilter
      ? this.filterEvents(this.searchFilter)
      : this.events;
  }

  // Constructor
  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  // Lifecycle Hooks
  public ngOnInit(): void {
    this.spinner.show();
    this.getEvents();
  }

  // Methods
  /**
   * Fetch events from the service.
   */
  public getEvents(): void {
    this.eventService.getEvents().subscribe({
      next: (events: Event[]) => {
        this.events = events;
        this.filteredEvents = this.events;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Não foi possível carregar os eventos.', 'Erro');
        console.error('Error retrieving events:', error);
      },
      complete: () => {
        this.spinner.hide();
      },
    });
  }

  /**
   * Filter events by the provided search value.
   * @param filterBy Search term
   * @returns Filtered events
   */
  public filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase().trim();
    return this.events.filter(
      (event) =>
        event.theme.toLocaleLowerCase().includes(filterBy) ||
        event.location.toLocaleLowerCase().includes(filterBy)
    );
  }

  /**
   * Open a modal with the provided template.
   * @param template Modal template reference
   */
  public openModal(template: TemplateRef<void>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  /**
   * Confirm action in the modal.
   */
  public confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O evento foi excluído com sucesso.', 'Exclusão Confirmada!')
  }

  /**
   * Decline action in the modal.
   */
  public decline(): void {
    this.modalRef?.hide();
  }
}
