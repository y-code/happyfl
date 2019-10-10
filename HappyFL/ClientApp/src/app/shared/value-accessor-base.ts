import { ControlValueAccessor } from '@angular/forms';


export class ValueAccessorBase<T> implements ControlValueAccessor {
  private _value: T;

  private _changed = new Array<(value: T) => void>();
  private _touched = new Array<() => void>();

  get value(): T {
    return this._value;
  }

  set value(value: T) {
    if (this._value !== value) {
      this._value = value;
      this._changed.forEach(f => f(value));
    }
  }

  touch() {
    this._touched.forEach(f => f());
  }

  writeValue(value: T) {
    this._value = value;
  }

  registerOnChange(fn: (value: T) => void) {
    this._changed.push(fn);
  }

  registerOnTouched(fn: () => void) {
    this._touched.push(fn);
  }

  updateValue(newValue: T, exclude: string[] = []) {
    if (!this.value)
      return;
    for (let propName in newValue)
      if (!exclude.includes(propName))
        this.value[propName] = newValue[propName];
  }
}
