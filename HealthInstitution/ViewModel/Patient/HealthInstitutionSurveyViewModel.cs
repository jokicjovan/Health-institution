﻿using System.Windows.Input;
using HealthInstitution.Commands.patient;
using HealthInstitution.Services.Intefaces;

namespace HealthInstitution.ViewModel.patient
{
    public class HealthInstitutionSurveyViewModel : ViewModelBase
    {
         #region services
        private readonly IHealthInstitutionSurveyService _healthInstitutionSurveyService;
        public IHealthInstitutionSurveyService HealthInstitutionSurveyService => _healthInstitutionSurveyService;
        #endregion

        #region attributes
        private int _serviceQualityRating;
        public int ServiceQualityRating
        {
            get => _serviceQualityRating;
            set
            {
                _serviceQualityRating = value;
                OnPropertyChanged(nameof(ServiceQualityRating));
            }
        }

        private int _cleanlinessRating;
        public int CleanlinessRating
        {
            get => _cleanlinessRating;
            set
            {
                _cleanlinessRating = value;
                OnPropertyChanged(nameof(CleanlinessRating));
            }
        }
        
        private int _serviceSatisfactionRating;
        public int ServiceSatisfactionRating
        {
            get => _serviceSatisfactionRating;
            set
            {
                _serviceSatisfactionRating = value;
                OnPropertyChanged(nameof(ServiceSatisfactionRating));
            }
        }

        private int _recommendationRating;
        public int RecommendationRating
        {
            get => _recommendationRating;
            set
            {
                _recommendationRating = value;
                OnPropertyChanged(nameof(RecommendationRating));
            }
        }

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        #endregion
        public ICommand FinishHealthInstitutionSurveyCommand { get; }
        public ICommand BackCommand { get; }
        #region commands

        #endregion

        public HealthInstitutionSurveyViewModel(IHealthInstitutionSurveyService healthInstitutionSurveyService)
        {
            _healthInstitutionSurveyService = healthInstitutionSurveyService;
            ServiceQualityRating = 1;
            RecommendationRating = 1;
            CleanlinessRating = 1;
            ServiceSatisfactionRating = 1;

            FinishHealthInstitutionSurveyCommand = new FinishHealthInstitutionSurveyCommand(this);
        }
    }
}
