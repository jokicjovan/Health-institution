﻿using HealthInstitution.Persistence;
using System.Collections.Generic;
using System.Linq;
using HealthInstitution.Services.Interfaces;
using HealthInstitution.Core.Features.AppointmentScheduling.Model;
using HealthInstitution.Core.Utility.HelperClasses;

namespace HealthInstitution.Services.Implementation
{
    public class AppointmentRequestService<T> : CrudService<T>, IAppointmentRequestService<T> where T : AppointmentRequest
    {
        public AppointmentRequestService(DatabaseContext context) : base(context)
        {

        }

        public IEnumerable<T> ReadAllPendingRequests()
        {
            return _entities.Where(r => r.Status == Status.Pending).ToList();
        }

        public IEnumerable<T> FilterPendingRequestsBySearchText(string searchText)
        {
            searchText = searchText.ToLower();
            return _entities.Where(r => r.Status == Status.Pending)
                            .Where(r => r.Patient.EmailAddress.ToLower().Contains(searchText) || r.CreatedAt.ToString().Contains(searchText)
                            || r.Patient.FirstName.ToLower().Contains(searchText)).ToList();
        }
    }
}
