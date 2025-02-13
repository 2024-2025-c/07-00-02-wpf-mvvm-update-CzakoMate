using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models.Entites.SchoolCitizens;
using Kreta.Shared.Models.Responses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class TeacherViewModel : BaseViewModel
    {
        private readonly ITeacherHttpService _httpService;
        [ObservableProperty]
        private ObservableCollection<Teacher> _teachers = new ObservableCollection<Teacher>();
        [ObservableProperty]
        private Teacher _selectedTeacher = new Teacher();
        public TeacherViewModel()
        {

        }

        public TeacherViewModel(ITeacherHttpService? httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }
        public override async Task InitializeAsync()
        {
            await UpdateViewAsync();
            await base.InitializeAsync();
        }


        [RelayCommand]
        private void DoNewTeacher()
        {
            ClearForm();
        }
        [RelayCommand]
        private async Task DoDeleteTeacher(Teacher teacher)
        {
            if (teacher is not null)
            {
                await _httpService.DeleteAsync(teacher.Id);
                ClearForm();
                await UpdateViewAsync();
            }
        }
        [RelayCommand]
        public async Task DoSaveTeacher(Teacher teacher)
        {
            if (teacher is not null)
            {
                Response response;
                if (teacher.HasId)
                    response = await _httpService.UpdateAsync(teacher);
                else
                    response = await _httpService.InsertAsync(teacher);
                ClearForm();
                await UpdateViewAsync();
            }
        }
        private void ClearForm()
        {
            SelectedTeacher = new Teacher();
            OnPropertyChanged(nameof(SelectedTeacher));
        }


        private async Task UpdateViewAsync()
        {
            List<Teacher> teachers = await _httpService.GetAllAsync();
            Teachers = new ObservableCollection<Teacher>(teachers);
        }
    }
}
