import { Input } from "@angular/core";
import { ValueAccessorBase } from "../shared/value-accessor-base";

export abstract class Combobox<T> extends ValueAccessorBase<T> {
  @Input()
  public name: string;

  @Input()
  public placeholder: string;

  private _options: T[];
  @Input()
  public set options(value: T[]) {
    this._options = value;
    if (this._options.length) {
      this.updateValue(this._options[0]);
    }
  }
  public get options(): T[] {
    return this._options;
  }

  public toggleFlg: boolean;

  abstract putBackFocus(): void;

  constructor(
  ) {
    super();
  }
  
  onOptionClick(event: Event, option: T): void {
    this.updateValue(option, [ "id", "section" ]);
    this.putBackFocus();
    event.preventDefault();
  }

  toggleOptions(event: Event) {
    this.toggleFlg = !this.toggleFlg;
    event.preventDefault();
    this.putBackFocus();
  }

  showOptions() {
    this.toggleFlg = true;
  }
  
  hideOptions() {
    this.toggleFlg = false;
  }
}