
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UtilityService {
    constructor(private http: Http) { }
    getUtilities() {
        return this.http.get('/api/utilities').map(res => res.json());
    }
}
