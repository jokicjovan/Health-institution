﻿using HealthInstitution.Commands;
using HealthInstitution.Model;
using HealthInstitution.Ninject;
using HealthInstitution.Services.Implementation;
using HealthInstitution.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthInstitution.ViewModel
{
    internal class DoctorHomeViewModel : NavigableViewModel
    {
        public ICommand? LogOutCommand { get; }
        public ICommand? NavigateScheduleCommand { get; }

        public string FullName
        {
            get => GlobalStore.ReadObject<Doctor>("LoggedUser").FullName;
        }
        public DoctorHomeViewModel()
        {
            LogOutCommand = new LogOutCommand();
            NavigateScheduleCommand = new NavigateScheduleCommand();
            SwitchCurrentViewModel(ServiceLocator.Get<DoctorScheduleViewModel>());
            RegisterHandler();
        }

        private void RegisterHandler()
        {
            EventBus.RegisterHandler("DoctorSchedule", () =>
            {
                DoctorScheduleViewModel viewModel = ServiceLocator.Get<DoctorScheduleViewModel>();
                SwitchCurrentViewModel(viewModel);
            });
            EventBus.RegisterHandler("MedicalHistory", () =>
            {
                //MedicalHistoryViewModel viewModel = ServiceLocator.Get<MedicalHistoryViewModel>();
                MedicalRecordViewModel viewModel = new MedicalRecordViewModel(ServiceLocator.Get<MedicalRecordService>(), GlobalStore.ReadObject<Patient>("SelectedPatient"));
                SwitchCurrentViewModel(viewModel);
            });
        }
    }
}
