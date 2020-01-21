import { BaseService } from './../base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarsService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
   }

   public getCars(url: string): Observable<any[]> {
    return this.get<any>(url);
  }

  public postCar(url: string, car: any): Observable<any> {
    return this.post<any>(url, car);
  }

  public deleteCar(url: string): Observable<any> {
    return this.delete<any>(url);
  }

  public updateCar(url: string, car: any): Observable<any> {
    return this.update(url, car);
  }
}
