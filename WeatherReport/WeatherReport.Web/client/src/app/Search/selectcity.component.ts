import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { City } from '../Models/City';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-SelectCity',
  templateUrl: './SelectCity.component.html',
  //styleUrls: []
})
export class SelectCityComponent implements OnInit {

  @Input() citiesList: City[];

  @Input() set form([f, name]: [FormGroup, string]) {
    f.setControl(name, this.cityForm);
  }

  @Output() onCitySelect = new EventEmitter();

  cityForm: FormGroup;

  constructor() {
    this.cityForm = new FormBuilder().group({
      'citySelect': ['', Validators.required]
    });
  }

  ngOnInit() {
  }

   onCityChange(event: Event, index: number): void {
     if (this.cityForm.valid) {
       this.onCitySelect.emit({ selectedCity: this.cityForm.get('citySelect').value });
     }
  }

}
