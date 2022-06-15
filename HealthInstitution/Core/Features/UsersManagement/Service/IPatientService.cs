﻿using HealthInstitution.Core.Features.UsersManagement.Model;
using System.Collections.Generic;
using HealthInstitution.Core.Utility;

namespace HealthInstitution.Core.Features.UsersManagement.Service
{
    public interface IPatientService : ICrudService<Patient>
    {
        void BlockPatient(Patient patientToBlock);

        IEnumerable<Patient> FilterBlockedPatientsBySearchText(string searchText);

        IEnumerable<Patient> FilterPatientsBySearchText(string searchText);

        IEnumerable<Patient> FilterValidPatientsBySearchText(string searchText);

        IEnumerable<Patient> ReadAllBlockedPatients();

        IEnumerable<Patient> ReadAllValidPatients();

        void UnblockPatient(Patient patientToUnblock);
    }
}