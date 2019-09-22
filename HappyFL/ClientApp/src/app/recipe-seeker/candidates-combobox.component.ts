import { Component, OnInit, Input, Output, ViewChild, ElementRef, EventEmitter } from '@angular/core';
import { ValueAccessorBase } from '../shared/value-accessor-base';
import { NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-candidates-combobox',
  template: `
    <div class="accordion main" id="accordionExample">
      <div class="card">
        <div
          class="card-header bg-secondary"
          (mousedown)="toggleOptions($event);">
          <div class="row control-main">
            <input
              #theInput
              [id]="name"
              [name]="name"
              type="text"
              class="form-control"
              [placeholder]="placeholder"
              [(ngModel)]="value"
              (mousedown)="$event.stopPropagation(); showOptions()"
              (focus)="showOptions()"
              (focusout)="hideOptions()" />
            <span class="btn">▼</span>
          </div>
        </div>
        <div
          *ngIf="options"
          class="collapse"
          [ngClass]="toggleFlg ? 'show' : ''">
          <div
            *ngIf="!options.length"
            class="card-body text-light non-candidate"
            [ngClass]="{ 'border-bottom' : i < options.length - 1 }"
            (mousedown)="$event.preventDefault()">
            No candidate was found.
          </div>
          <div
            *ngFor="let option of options; let i = index"
            class="card-body"
            [ngClass]="{ 'border-bottom' : i < options.length - 1 }"
            (mousedown)="onOptionClick($event, option)">
            {{option}}
          </div>
        </div>
      </div>
    </div>
  `,
  styles: [
    '.main { cursor: pointer; }',
    '.control-main { align-items: center }',
    '.non-candidate { cursor: default }',
    '.card-header { padding-top: 5px; padding-bottom: 5px; }',
    '.card-body { padding: 13px; }',
    '.accordion div.card:only-child { border-bottom: 1px solid rgba(0, 0, 0, 0.125); border-radius: calc(0.5rem - 1px); }',
    'input { flex: 1 }'
  ],
  providers: [
    { provide: NG_VALUE_ACCESSOR, useExisting: CandidatesComboboxComponent, multi: true },
  ],
})
export class CandidatesComboboxComponent extends ValueAccessorBase<string> implements OnInit {
  @Input()
  public name: string;

  @Input()
  public placeholder: string;

  @Input()
  public options: string[];

  public toggleFlg: boolean;

  @ViewChild("theInput", { static: true })
  public inputElement: ElementRef;

  constructor(
  ) {
    super();
  }

  ngOnInit() {
  }

  onOptionClick(event: Event, option: string): void {
    this.value = option;
    this.inputElement.nativeElement.focus();
    event.preventDefault();
  }

  toggleOptions(event: Event) {
    this.toggleFlg = !this.toggleFlg;
    event.preventDefault();
    this.inputElement.nativeElement.focus();
  }

  showOptions() {
    this.toggleFlg = true;
  }
  
  hideOptions() {
    this.toggleFlg = false;
  }
}
