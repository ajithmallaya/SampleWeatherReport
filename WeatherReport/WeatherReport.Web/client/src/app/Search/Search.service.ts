import { GeoLocation } from '../Models/GeoLocations';
import { Weather } from '../Models/Weather';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Http, Response, Request, RequestMethod, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class SearchService {
 locations: GeoLocation[];
    constructor(private http: HttpClient) { }
    
    getWeatherReport(country: string, city: string): Observable<Weather> {
        const url = 'http://local.finest.online.cba:2222/Weather/' + country + '/' + city;
        const headers = new Headers();
        console.log(url);
        const response = this.http.get<Response>(url);
        console.log(response);
        return this.http.get<Response>(url).map(x => this.handleResponse(x));
        //return this.handleResponse(response);
    }
    handleResponse(res: Response): Weather {
        const data = res.json();
        console.log(data);
        if (data.error) {
            console.log(data.error);
        } else {
          return data;
        }
      }
    handleError(error: Response) {
        return Observable.throw({
            status: error.status,
            statusText: error.statusText,
            message: 'error'
        });
    }
}