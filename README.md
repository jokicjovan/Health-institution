## Introduction

The Health Institution application is a desktop application designed for medical staff, managers, and secretaries to manage the operations of a health institution. The application is written in C# using WPF and SQLite, and incorporates clean code principles to ensure maintainability and scalability. The application uses Entity Framework for data access and Ninject for dependency injection.

## Features

### Patient Management System

The application includes a patient management system that allows medical staff to create new patient records, update existing records, and view patient information as needed.

### Medical Staff Scheduling System

The application includes a medical staff scheduling system that allows medical staff to view their own schedule, request days off, check the availability of rooms and medical equipment, and manage appointments based on availability. Patients can also schedule appointments themselves if a doctor is available for that time. The system includes an appointment recommendation feature that recommends the appropriate medical staff for each appointment based on the patient's medical history.

### Medication Schedule System

The application includes a medication schedule system that allows medical staff to prescribe medication for patients and set reminders for patients to take their medication. The system allows medical staff to view medication history and monitor patient compliance with medication schedules. Patients receive notifications for their medication schedules.

### Rooms Renovation System

The application includes a system for managing room renovations. Managers can mark a room as unavailable for a period of time due to renovation work. Patients cannot schedule appointments for a room that is undergoing renovation.

### Medical Gear Transfer System

The application includes a system for managing the transfer of medical gear from one room to another. Managers can specify the type of medical gear that needs to be transferred and the destination room. The system keeps track of the current location of all medical gear and notifies staff when a transfer is required.

### Request Management System

The application includes a feature for managing requests made by patients or medical staff. This feature is handled by the secretary, who is responsible for managing the requests and forwarding them to the appropriate personnel. The request management system allows patients or medical staff to submit requests for appointments, medical gear, or other resources. The system provides a dashboard for managing and tracking the requests. The secretary can view and update the status of each request and forward it to the appropriate medical staff or manager for further action.

### Survey System

The application includes a survey system that allows patients to provide feedback on their experience at the health institution. The system provides customizable surveys that can be accessed via the application. The system collects and analyzes survey responses to identify areas for improvement.

### Operation Scheduling System

The application includes an operation scheduling system that allows medical staff to schedule operations for patients. Only doctors can schedule operations.

### Staff Performance System

The application includes a staff performance system that allows managers to evaluate the performance of medical staff. The system tracks performance metrics such as patient satisfaction ratings, appointment completion rates, and medication compliance rates.

### Customizable Reporting System

The application includes a customizable reporting system that allows managers to generate reports on various aspects of the health institution's operations. The system provides a variety of report templates that can be exported to various file formats.

## Dependencies

The Health Institution application has the following dependencies:

* C#
* WPF
* SQLite
* Entity Framework
* Ninject

## Conclusion

The Health Institution application provides a comprehensive solution for managing the operations of a health institution. The application includes features for managing patient information, scheduling appointments, prescribing medication, managing room renovations, transferring medical gear, managing requests, conducting surveys, scheduling operations, and evaluating staff performance. The application is written in C# using WPF and SQLite, and incorporates clean code principles to ensure maintainability and scalability. The application uses Entity Framework for data access and Ninject

## Roles

The application was divided into four roles and each role was developed by one person:

- Manager was developed by <a href="http://github.com/janosevicsm">Marko Janošević</a> 
- Doctor was developed by <a href="http://github.com/ForLoop111">Vlada Dević</a>
- Patient was developed by <a href="http://github.com/jokicjovan">Jovan Jokić</a>
- Secretary was developed by <a href="http://github.com/serbedzijajovan">Jovan Šerbedžija</a> 
