﻿using HealthInstitution.Utility;
using HealthInstitution.ViewModel.doctor;

namespace HealthInstitution.Commands.doctor.Navigation
{
    public class NavigateDoctorAppointmentCreationCommand : CommandBase
    {
        private DoctorScheduleViewModel _viewModel;
        public NavigateDoctorAppointmentCreationCommand(DoctorScheduleViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {         
            EventBus.FireEvent("CreateAppointment");
        }
    }
}
