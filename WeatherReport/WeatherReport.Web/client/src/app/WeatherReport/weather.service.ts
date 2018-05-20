import { Injectable } from '@angular/core';
import { Weather } from '../Models/Weather';

@Injectable()

export class WeatherService {
    weather: Weather;

    constructor() { }

    getWeatherReport(weather: string) {
        const weatherObj = JSON.parse(weather);
        this.weather = new Weather(
            weatherObj.country,
            weatherObj.City,
            weatherObj.Time,
            weatherObj.Wind,
            weatherObj.Time,
            weatherObj.Visibility,
            weatherObj.SkyConditions,
            weatherObj.Temperature,
            weatherObj.DewPoint,
            weatherObj.RelativeHumidity,
            weatherObj.Pressure
        );
    }

    
}
