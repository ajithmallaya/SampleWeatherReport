import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './search.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Observable } from 'rxjs/Rx';

@NgModule({
  imports: [CommonModule],
  declarations: [SearchComponent],
  exports: [SearchComponent]
})
export class SearchModule { }
