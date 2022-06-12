﻿using HealthInstitution.Model;
using System.Collections.Generic;
using HealthInstitution.Model.doctor;
using HealthInstitution.Model.user;

namespace HealthInstitution.Services.Intefaces
{
    public interface IDoctorService : IUserService<Doctor>
    {
        public IEnumerable<Doctor> FilterDoctorsBySearchText(string searchText);
        public IList<Doctor> GetDoctorsForDoctorSpecialization(DoctorSpecialization doctorSpecialization);
        public IEnumerable<Doctor> FindDoctorsWithSpecialization(DoctorSpecialization specialization);
    }
}
