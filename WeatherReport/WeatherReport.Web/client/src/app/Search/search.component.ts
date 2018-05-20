import { Component, Input, Output, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Weather } from './../Models/Weather';
import { GeoLocation } from './../Models/GeoLocations';
import { Observable } from 'rxjs/Observable';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-Search',
  templateUrl: './search.component.html',
  //styleUrls: []
})
export class SearchComponent implements OnInit {

 @Output() onCountrySearch = new EventEmitter();
  //searchForm: FormGroup;



  titleAlert = 'This field is required';
  errorMessage: string;

  constructor() {
    // this.searchForm = new FormBuilder().group({
    //   'searchCountry': ['', Validators.required],
    //   'validate': ''
    // });
  }

  ngOnInit() {}

  onSearch() {
    // if (this.searchForm.valid) {
    //   this.onCountrySearch.emit({ searchCountry: this.searchForm.get('searchCountry').value });
    // }
  }

  
}

