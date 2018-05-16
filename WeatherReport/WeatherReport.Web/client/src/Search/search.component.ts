import { Component, Input, Output, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Weather } from './../Models/Weather';
import { GeoLocation } from './../Models/GeoLocations';
import { Observable } from 'rxjs/Observable';


@Component({
  selector: 'app-Search',
  templateUrl: './search.component.html',
  styleUrls: []
})
export class SearchComponent implements OnInit {

  @Input() set form([f, name]: [FormGroup, string]) {
    f.setControl(name, this.searchForm);
  }
  @Output() onCountrySearch = new EventEmitter();
  searchForm: FormGroup;



  titleAlert = 'This field is required';
  errorMessage: string;

  constructor(private fb: FormBuilder) {
    this.searchForm = fb.group({
      'searchCountry': ['', Validators.required],
      'validate': ''
    });
  }

  ngOnInit() {}

  onSearch() {
    if (this.searchForm.valid) {
      this.onCountrySearch.emit({ searchCountry: this.searchForm.get('searchCountry').value });
    }
  }
}

