import { WeatherService } from './../WeatherReport/weather.service';
import { Weather } from './../Models/Weather';
import { Component, ElementRef, OnInit } from '@angular/core';


@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['weather.component.css']
})
export class WeatherComponent implements OnInit {

    weather: Weather;
   
    constructor(private weatherService: WeatherService) { }

    ngOnInit() {
        this.weather = this.weatherService.weather;
    }
}
