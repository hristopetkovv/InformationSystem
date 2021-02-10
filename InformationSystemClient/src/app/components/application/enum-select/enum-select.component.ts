import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
@Component({
  selector: 'enum-select',
  templateUrl: './enum-select.component.html',
  styleUrls: ['./enum-select.component.css']
})
export class EnumSelectComponent {
  keys: number[];

  type: any;
  @Input('type') set typeSetter(value: any) {
    if (!value) {
      return;
    }

    this.keys = Object.keys(value)
      .filter(k => !isNaN(Number(k)))
      .map(k => Number(k));

    this.type = value;
  }

  @Input() model: any;
  @Output() modelChange: EventEmitter<any> = new EventEmitter();
}
