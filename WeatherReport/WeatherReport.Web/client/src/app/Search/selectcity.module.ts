import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectCityComponent } from './selectcity.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule],
  declarations: [SelectCityComponent],
  exports: [SelectCityComponent]
})
export class SelectCityModule { }
