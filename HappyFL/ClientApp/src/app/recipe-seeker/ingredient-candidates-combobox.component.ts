import { Component, OnInit, Input, ViewChild, ElementRef, Inject } from '@angular/core';
import { ValueAccessorBase } from '../shared/value-accessor-base';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { DOCUMENT } from '@angular/common';
import { Ingredient } from '../model/recipe-management';

@Component({
  selector: 'app-ingredient-candidates-combobox',
  template: `
    <div class="accordion main" id="accordionExample">
      <div class="card">
        <div
          class="card-header bg-secondary"
          (mousedown)="toggleOptions($event);">
          <div class="row control-main">
            <div class="container inputs">
              <div class="row">
                <input
                  #nameInput
                  id="{{name}}Name"
                  name="{{name}}Name"
                  type="text"
                  class="ingredient-candidate-name form-control"
                  placeholder="Ingredient Name"
                  [ngModel]="value?.name"
                  (ngModelChange)="value.name = $event"
                  (mousedown)="$event.stopPropagation(); showOptions()"
                  (focus)="showOptions()"
                  (focusout)="hideOptions()" />
                <input
                  #amountInput
                  id="{{name}}Amount"
                  name="{{name}}Amount"
                  type="text"
                  class="ingredient-candidate-amount form-control"
                  placeholder="Amount"
                  [ngModel]="value?.amount"
                  (ngModelChange)="value.amount = $event"
                  (mousedown)="$event.stopPropagation(); showOptions()"
                  (focus)="showOptions()"
                  (focusout)="hideOptions()" />
                <input
                  #unitInput
                  id="{{name}}Unit"
                  name="{{name}}Unit"
                  type="text"
                  class="ingredient-candidate-unit form-control"
                  placeholder="Unit"
                  [ngModel]="value?.unit"
                  (ngModelChange)="value.unit = $event"
                  (mousedown)="$event.stopPropagation(); showOptions()"
                  (focus)="showOptions()"
                  (focusout)="hideOptions()" />
                <input
                  #noteInput
                  id="{{name}}Note"
                  name="{{name}}Note"
                  type="text"
                  class="ingredient-candidate-note form-control"
                  placeholder="Please enter any notes if you have."
                  [ngModel]="value?.note"
                  (ngModelChange)="value.note = $event"
                  (mousedown)="$event.stopPropagation(); showOptions()"
                  (focus)="showOptions()"
                  (focusout)="hideOptions()" />
              </div>
              <div class="row" *ngIf="original">
                <small class="col-12 text-muted">In original site, it was "{{original}}"</small>
              </div>
            </div>
            <span class="btn">▼</span>
          </div>
        </div>
        <div
          *ngIf="options"
          class="collapse"
          [ngClass]="toggleFlg ? 'show' : ''">
          <div
            *ngFor="let option of options; let i = index"
            class="card-body row"
            [ngClass]="{ 'border-bottom' : i < options.length - 1 }"
            (mousedown)="onOptionClick($event, option)">
            <div class="col-lg-6 col-8">{{option.name}}</div>
            <div class="col-lg-3 col-4">{{option.amount}} {{option.unit}}</div>
            <div class="col-lg-3 col-12">{{option.note}}</div>
          </div>
        </div>
      </div>
    </div>
  `,
  styles: [
    '.main { cursor: pointer; }',
    '.control-main { align-items: center }',
    '.accordion div.card:only-child { border-bottom: 1px solid rgba(0, 0, 0, 0.125); border-radius: calc(0.5rem - 1px); }',
    '.card-header { padding-top: 5px; padding-bottom: 5px; }',
    '.card-body { padding: 13px; }',
    ` .inputs { flex: 1 }
      input.ingredient-candidate-name { flex: 5 }
      input.ingredient-candidate-amount { flex: 2 }
      input.ingredient-candidate-unit { flex: 1 }
      input.ingredient-candidate-note { flex: 100% }`,
    `@media (min-width: 992px) {
      input.ingredient-candidate-name { flex: 5 }
      input.ingredient-candidate-amount { flex: 2 }
      input.ingredient-candidate-unit { flex: 1 }
      input.ingredient-candidate-note { flex: 5 }
    }`,
  ],
  providers: [
    { provide: NG_VALUE_ACCESSOR, useExisting: IngredientCandidatesComboboxComponent, multi: true },
  ],
})
export class IngredientCandidatesComboboxComponent extends ValueAccessorBase<Ingredient> implements OnInit {
  @Input()
  public name: string;

  @Input()
  public placeholder: string;

  private _options: Ingredient[];
  @Input()
  public set options(value: Ingredient[]) {
    this._options = value;
    if (this._options.length) {
      this.updateValue(this._options[0]);
    }
  }
  public get options(): Ingredient[] {
    return this._options;
  }

  @Input()
  public original: string;

  public toggleFlg: boolean;

  @ViewChild("nameInput", { static: true })
  public nameInputElement: ElementRef;

  @ViewChild("amountInput", { static: true })
  public amountInputElement: ElementRef;

  @ViewChild("unitInput", { static: true })
  public unitInputElement: ElementRef;

  @ViewChild("noteInput", { static: true })
  public noteInputElement: ElementRef;

  constructor(
    @Inject(DOCUMENT)
    private document: Document,
  ) {
    super();
  }

  ngOnInit() {
  }

  private updateValue(newValue: Ingredient) {
    if (!this.value)
      return;
    for (let propName in newValue)
      this.value[propName] = newValue[propName];
  }

  onOptionClick(event: Event, option: Ingredient): void {
    this.updateValue(option);
    this.putBackFocus();
    event.preventDefault();
  }

  toggleOptions(event: Event) {
    this.toggleFlg = !this.toggleFlg;
    event.preventDefault();
    this.putBackFocus();
  }

  putBackFocus() {
    if (this.document.activeElement.isSameNode(this.nameInputElement.nativeElement))
      (this.document.activeElement as any).focus();
    else if (this.document.activeElement.isSameNode(this.amountInputElement.nativeElement))
      (this.document.activeElement as any).focus();
    else if (this.document.activeElement.isSameNode(this.unitInputElement.nativeElement))
      (this.document.activeElement as any).focus();
    else if (this.document.activeElement.isSameNode(this.noteInputElement.nativeElement))
      (this.document.activeElement as any).focus();
    else
      this.nameInputElement.nativeElement.focus();
  }

  showOptions() {
    this.toggleFlg = true;
  }
  
  hideOptions() {
    this.toggleFlg = false;
  }
}
