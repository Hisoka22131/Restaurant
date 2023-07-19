import {Component, Input, Output, EventEmitter, forwardRef} from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-select-box',
  templateUrl: './select-box.component.html',
  styleUrls: ['./select-box.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SelectBoxComponent),
      multi: true,
    },
  ],
})
export class SelectBoxComponent {
  @Input() items: Array<any> = [];
  @Input() selectedItem: any;
  @Output() selectedItemChange: EventEmitter<any> = new EventEmitter<any>();

  onChange: any = () => {};
  onTouched: any = () => {};

  writeValue(value: any) {
    this.selectedItem = value;
  }

  registerOnChange(fn: any) {
    this.onChange = fn;
  }

  registerOnTouched(fn: any) {
    this.onTouched = fn;
  }

  onSelectedChange(value: number) {
    this.selectedItem = value;
    this.selectedItemChange.emit(value);
    this.onChange(value);
    this.onTouched();
  }
}
