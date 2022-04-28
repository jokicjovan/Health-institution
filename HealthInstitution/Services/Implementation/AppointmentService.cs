﻿using HealthInstitution.Model;
using HealthInstitution.Persistence;
using HealthInstitution.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthInstitution.Services.Implementation
{
    public class AppointmentService : CrudService<Appointment>, IAppointmentService
    {
        public AppointmentService(DatabaseContext context) : base(context)
        {

        }

        public IEnumerable<Appointment> ReadDoctorAppointemnts(Doctor doc, DateTime fromDate, DateTime toDate)
        {
            return _entities.Where(apt => apt.Doctor == doc && apt.StartDate < toDate && fromDate < apt.EndDate).ToList();
        }

        public IEnumerable<Appointment> ReadDoctorAppointemntsWithoutChosen(Doctor doc, DateTime fromDate, DateTime toDate, Appointment chosenAppointment)
        {
            return _entities.Where(apt => apt != chosenAppointment && apt.Doctor == doc && apt.StartDate < toDate && fromDate < apt.EndDate).ToList();
        }

        public IEnumerable<Appointment> ReadAppointemntsInInterval(DateTime fromDate, DateTime toDate)
        {
            return _entities.Where(apt => apt.StartDate < toDate && fromDate < apt.EndDate).ToList();
        }

        public IEnumerable<Appointment> ReadAppointemntsInIntervalWithoutChosen(DateTime fromDate, DateTime toDate, Appointment chosenAppointment) 
        {
            return _entities.Where(apt => apt != chosenAppointment && apt.StartDate < toDate && fromDate < apt.EndDate).ToList();
        }

        public IEnumerable<Appointment> ReadPatientAppointments(Patient pt)
        {
            return _entities.Where(apt => apt.Patient == pt).ToList();
        }

        public IEnumerable<Appointment> ReadRoomAppointments(Room r)
        {
            return _entities.Where(apt => apt.Room == r).ToList();
        }
    }
}
