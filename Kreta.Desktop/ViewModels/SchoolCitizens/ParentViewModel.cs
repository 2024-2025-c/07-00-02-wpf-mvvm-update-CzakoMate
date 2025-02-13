using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models.Entites;
using Kreta.Shared.Models.Entites.SchoolCitizens;
using Kreta.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class ParentViewModel : BaseViewModel
    {
        private readonly IParentHttpService _httpService;
        [ObservableProperty]
        private ObservableCollection<Parent> _parents = new ObservableCollection<Parent>();
        [ObservableProperty]
        private Parent _selectedParent = new Parent();
        public ParentViewModel()
        {

        }
        
        public ParentViewModel(IParentHttpService? httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }
        public override async Task InitializeAsync()
        {
            await UpdateViewAsync();
            await base.InitializeAsync();
        }


        [RelayCommand]
        private void DoNewParent()
        {
            ClearForm();
        }
        [RelayCommand]
        private async Task DoDeleteParent(Parent parent)
        {
            if (parent is not null)
            {
                await _httpService.DeleteAsync(parent.Id);
                ClearForm();
                await UpdateViewAsync();
            }
        }
        [RelayCommand]
        public async Task DoSaveParent(Parent parent)
        {
            if (parent is not null)
            {
                Response response;
                if (parent.HasId)
                    response = await _httpService.UpdateAsync(parent);
                else
                    response = await _httpService.InsertAsync(parent);
                ClearForm();
                await UpdateViewAsync();
            }
        }
        private void ClearForm()
        {
            SelectedParent = new Parent();
            OnPropertyChanged(nameof(SelectedParent));
        }


        private async Task UpdateViewAsync()
        {
            List<Parent> parents = await _httpService.GetAllAsync();
            Parents = new ObservableCollection<Parent>(parents);
        }
    }
}
