﻿using HealthInstitution.Commands;
using HealthInstitution.Model;
using HealthInstitution.Services.Intefaces;
using HealthInstitution.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthInstitution.ViewModel
{
    public class PatientMedicalRecordViewModel : ViewModelBase
    {
        #region services
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IAppointmentService _appointmentService;

        public IMedicalRecordService MedicalRecordService => _medicalRecordService;
        public IAppointmentService AppointmentService => _appointmentService;
        #endregion

        #region attributes
        private MedicalRecord _medicalRecord;
        public MedicalRecord MedicalRecord
        {
            get => _medicalRecord;
            set
            {
                _medicalRecord = value;
                OnPropertyChanged(nameof(MedicalRecord));
            }
        }

        private Patient _patient;
        public Patient Patient
        {
            get => _patient;
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        public string Height => MedicalRecord.Height.ToString();
        public string Age => CalculateAge(Patient.DateOfBirth).ToString();
        public string Weight => MedicalRecord.Weight.ToString();

        private List<Illness> _illnessHistory;
        public List<Illness> IllnessHistory
        {
            get => _illnessHistory;
            set
            {
                _illnessHistory = value;
                OnPropertyChanged(nameof(IllnessHistory));
            }
        }

        private List<Allergen> _allergens;
        public List<Allergen> Allergens
        {
            get => _allergens;
            set
            {
                _allergens = value;
                OnPropertyChanged(nameof(Allergens));
            }
        }

        private List<Appointment> _pastAppointments;
        public List<Appointment> PastAppointments
        {
            get => _pastAppointments;
            set
            {
                _pastAppointments = value;
                OnPropertyChanged(nameof(PastAppointments));
            }
        }

        private Appointment _selectedAppointment;
        public Appointment SelectedAppointment 
        {
            get => _selectedAppointment;
            set 
            {
                _selectedAppointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }

        private string _anamnesisSearchCriteria;
        public string AnamnesisSearchCriteria
        {
            get => _anamnesisSearchCriteria;
            set
            {
                _anamnesisSearchCriteria = value;
                OnPropertyChanged(nameof(AnamnesisSearchCriteria));
            }
        }

        private string _selectedSort;
        public string SelectedSort
        {
            get => _selectedSort;
            set
            {
                _selectedSort = value;

                if (SelectedSort.Equals("Date"))
                {
                    PastAppointments = PastAppointments.OrderBy(apt => apt.StartDate).ToList<Appointment>();
                }
                else if (SelectedSort.Equals("Doctor"))
                {
                    PastAppointments = PastAppointments.OrderBy(apt => apt.Doctor.FullName).ToList<Appointment>();
                }
                else if (SelectedSort.Equals("Specialization"))
                {
                    PastAppointments = PastAppointments.OrderBy(apt => apt.Doctor.Specialization).ToList<Appointment>();
                }
                OnPropertyChanged(nameof(SelectedSort));
            }
        }
        #endregion

        #region commands
        public ICommand SearchByAnamnesisCommand { get; }
        #endregion

        #region methods
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dateOfBirth).Days;
            age = age / 365;
            return age;
        }

        public void SearchByAnamnesis(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                PastAppointments = AppointmentService.FilterFinishedAppointmentsByAnamnesisSearchText(text, Patient).ToList<Appointment>();
            }
            else
            {
                PastAppointments = AppointmentService.ReadFinishedAppointmentsForPatient(Patient).ToList<Appointment>();
            }
            SelectedSort = "";
        }
        #endregion

        public PatientMedicalRecordViewModel(IMedicalRecordService medicalRecordService, IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            _medicalRecordService = medicalRecordService;

            _selectedSort = "";
            _patient = GlobalStore.ReadObject<Patient>("LoggedUser");
            _medicalRecord = medicalRecordService.GetMedicalRecordForPatient(Patient);
            _illnessHistory = _medicalRecord.IllnessHistory.ToList<Illness>();
            _allergens = _medicalRecord.Allergens.ToList<Allergen>();
            _pastAppointments = appointmentService.ReadFinishedAppointmentsForPatient(Patient).ToList<Appointment>();

            SearchByAnamnesisCommand = new SearchByAnamnesisCommand(this);
        }
    }
}
