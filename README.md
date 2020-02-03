You need to create a system to display real-time information from devices that are installed in the vehicles. To achieve this you need 
write an API endpoint, that would allow us to push information from vehicles that are registered in this system. Data can be displayed
in a simple table (only latest information from each vehicle)

Vehicles will send data in such format: 
{
 "latitude": 55.141210,
 "longitude": 24.016113,
 "speed": 55
}

Requirements:
 1. Create a REST API based on .NET core.
 2. Create a SPA application using Angular 8.
 3. Ability to add new vehicle through UI and receive information from that vehicle.
 4. Save received data in a database.
 5. Ability to review all received data from a specific vehicle.
 6. Select and follow architecture patterns across your solution.
 7. Select one of the frontend frameworks for html/css.

Bonus points:
 1. State management in Angular application.
 2. Push real-time information from API instead of pulling.
 3. Ability to see information from vehicles in a map.
 4. Docker support for backend and frontend applications.
 5. Various forms of tests (Unit/Integration/System/Frontend).
 6. Responsive design.
