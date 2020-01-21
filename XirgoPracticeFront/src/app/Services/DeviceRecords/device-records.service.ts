import { BaseService } from './../base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeviceRecordsService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
  }

  public getDeviceRecords(url: string): Observable<any[]> {
    return this.get<any>(url);
  }

  public postDeviceRecord(url: string, user: any): Observable<any> {
    return this.post<any>(url, user);
  }

  public deleteDeviceRecord(url: string): Observable<any> {
    return this.delete<any>(url);
  }

  public UpdateDeviceRecord(url: string, user: any): Observable<any> {
    return this.update(url, user);
  }
}
