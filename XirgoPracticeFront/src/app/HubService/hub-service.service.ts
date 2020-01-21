import { Injectable, Output, EventEmitter } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class HubServiceService {

  private hubConnection: signalR.HubConnection;
  @Output() vehicleCreationSignal = new EventEmitter();
  @Output() vehicleUpdateSignal = new EventEmitter();
  @Output() deviceRecordCreationSignal = new EventEmitter();
  @Output() deviceRecordUpdateSignal = new EventEmitter();

  constructor() {
    this.buildConnection();
    this.startConnection();
   }

  public buildConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('http://localhost:60660/trackinghub')
    .build();
  }

  public startConnection = () => {
    this.hubConnection.start()
    .then(() => {
      this.registerSignalEvents();
  })
    .catch(err => {
      console.log('Error while starting connection with hub: ' + err);

      setTimeout(function() {this.startConnection(); }, 3000);
    });
  }

  private registerSignalEvents() {
    this.hubConnection.on('VehicleCreated', (data: any) => {
      this.vehicleCreationSignal.emit(data);
    });
    this.hubConnection.on('VehicleUpdated', (data: any) => {
      this.vehicleUpdateSignal.emit(data);
    });
    this.hubConnection.on('DeviceRecordCreated', (data: any) => {
      this.deviceRecordCreationSignal.emit(data);
    });
    this.hubConnection.on('DeviceRecordUpdated', (data: any) => {
      this.deviceRecordUpdateSignal.emit(data);
    });
  }
}
