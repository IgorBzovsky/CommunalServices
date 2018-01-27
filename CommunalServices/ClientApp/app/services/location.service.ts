
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class LocationService {
    constructor(private http: Http) { }
    getRegions() {
        return this.http.get('/api/regions').map(res => res.json());
    }
}
