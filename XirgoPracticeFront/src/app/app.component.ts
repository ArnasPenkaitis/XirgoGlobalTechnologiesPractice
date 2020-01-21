import { DeviceRecordsService } from './Services/DeviceRecords/device-records.service';
import { CarsService } from './Services/Cars/cars.service';
import { HubServiceService } from './HubService/hub-service.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {
  selectedLatitude = 32;
  selectedLongitude = 0;
  mapZoom = 2;
  vehiclesList = [];
  selectedVehiclesDeviceRecords = [];
  selectedVehicle: any;
  newCarInput = '';

  constructor(private signalRService: HubServiceService, private vehicleService: CarsService
    ,         private deviceRecordsService: DeviceRecordsService) {}

  ngOnInit() {
    this.signalRService.vehicleCreationSignal.subscribe((signal: any) => {
      this.onVehicleCreatedEvent(signal);
    });
    this.signalRService.vehicleUpdateSignal.subscribe((signal: any) => {
      this.onVehicleUpdatedEvent(signal);
    });
    this.signalRService.deviceRecordCreationSignal.subscribe((signal: any) => {
      this.onDeviceRecordCreatedEvent(signal);
    });
    this.signalRService.deviceRecordUpdateSignal.subscribe((signal: any) => {
      this.onDeviceRecordUpdatedEvent(signal);
    });
    this.vehicleService.getCars('http://localhost:60660/api/cars').subscribe(items => {this.vehiclesList = items; } );
  }

  onKey(event: any) {
    this.newCarInput = event.target.value;
  }


  onVehicleSelect(vehicle: any) {
    this.deviceRecordsService.getDeviceRecords('http://localhost:60660/api/cars/' + vehicle.id + '/devicerecords')
    .subscribe(items => {
      this.selectedVehiclesDeviceRecords = [];
      this.selectedLatitude = 32;
      this.selectedLongitude = 0;
      this.mapZoom = 2;
      this.selectedVehicle = vehicle;
      this.selectedVehiclesDeviceRecords = items;
      if (this.selectedVehiclesDeviceRecords.length > 0) {
        this.selectedLatitude = this.selectedVehiclesDeviceRecords[0].latitude;
        this.selectedLongitude = this.selectedVehiclesDeviceRecords[0].longitude;
        this.mapZoom = 17;
      }
   } );
  }

  onVehicleCreatedEvent(signal: any) {
    this.vehiclesList.push(signal);
  }

  onVehicleUpdatedEvent(signal: any) {
    this.vehiclesList.forEach(element => {
      if (element.id === signal.id) {
        element.name = signal.name;
      }
    });
  }

  onDeviceRecordCreatedEvent(signal: any) {
    this.selectedVehiclesDeviceRecords = [ signal, ...this.selectedVehiclesDeviceRecords ];
    this.selectedLatitude = signal.latitude;
    this.selectedLongitude = signal.longitude;
    this.mapZoom = 17;
  }
  onDeviceRecordUpdatedEvent(signal: any) {
    this.selectedVehiclesDeviceRecords.forEach(element => {
      if (element.id === signal.id) {
        element.latitude = signal.latitude;
        element.longitude = signal.longitude;
        element.speed = signal.speed;
      }
    });
  }

  onCreateVehicleButtonClicked() {
    const temporary = { name: this.newCarInput };
    if (this.newCarInput.length > 0) {
      this.vehicleService.postCar('http://localhost:60660/api/cars', temporary).subscribe(result => {
        this.newCarInput = 'Created!';
      });
    }
  }
}
