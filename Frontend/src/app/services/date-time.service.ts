import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DateTimeService {
  private apiUrl = 'http://worldtimeapi.org/api/ip';

  constructor(private http: HttpClient) {
  }

  getCurrentDateTime(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
