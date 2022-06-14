﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInstitution.Core.Features.MedicalRecordManagement.Repository
{
    public class AllergenRepository : CrudRepository<Allergen>, IAllergenRepository
    {
        public AllergenRepository(DatabaseContext context) : base(context) { }
    }
}
