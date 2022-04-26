﻿using HealthInstitution.Model;
using System.Collections.Generic;

namespace HealthInstitution.Model
{
    /// <summary>
    /// Proveri dal ide virtual kod IList<string>
    /// </summary>
    public class MedicalRecord : BaseObservableEntity
    {
        #region Attributes

        private double _height;
        public double Height { get => _height; set => OnPropertyChanged(ref _height, value); }

        private double _weight;
        public double Weight { get => _weight; set => OnPropertyChanged(ref _weight, value); }

        private IList<Illness> _illnessHistory;
        public virtual IList<Illness> IllnessHistory { get => _illnessHistory; set => OnPropertyChanged(ref _illnessHistory, value); }

        private IList<Allergen> _allergens;
        public virtual IList<Allergen> Allergens { get => _allergens; set => OnPropertyChanged(ref _allergens, value); }

        private Patient _patient;
        public virtual Patient Patient { get => _patient; set => OnPropertyChanged(ref _patient, value); }

        #endregion

        #region Constructor

        public MedicalRecord() { }
        public MedicalRecord(double height, double weight, Patient patient)
        {
            _height = height;
            _weight = weight;
            _illnessHistory = new List<Illness>();
            _allergens = new List<Allergen>();
            _patient = patient;
        }

        #endregion

        #region Methods

        public void AddIllness(Illness illness)
        {
            foreach (Illness includedIllness in IllnessHistory)
            {
                if (includedIllness.Equals(illness))
                {
                    // Baci exception
                    return;
                }
            }
            IllnessHistory.Add(illness);
        }

        public void AddAllergen(Allergen allergen)
        {
            foreach (Allergen includedAllergen in Allergens)
            {
                if (includedAllergen.Equals(allergen))
                {
                    // Baci exception
                    return;
                }
            }
            Allergens.Add(allergen);
        }

        #endregion
    }
}
