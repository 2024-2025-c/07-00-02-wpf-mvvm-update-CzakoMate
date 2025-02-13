﻿using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Kreta.Desktop.ViewModels.SchoolSubjects
{
    public partial class SubjectsManagmentViewModel : BaseViewModel
    {
        private readonly ISubjectHttpService _httpService;
        public SubjectsManagmentViewModel()
        {
            
        }

        //1.b Konstruktorban injektáljuk a ISubjectHttpService-t
        public SubjectsManagmentViewModel(ISubjectHttpService? httpService)
        {
           _httpService=httpService?? throw new ArgumentNullException(nameof(httpService));
        }

        //1.feladat: tantárgyak lekérése a backendről (vizsgaremek)
        //1.a Adatok menüpont kiválasztására jelenjenek meg: InitializeAsync
        public override async Task InitializeAsync()
        {
            await UpdateViewAsync();
            base.InitializeAsync();
        }

        //1.c Adatok lekérése a backendről
        private async Task UpdateViewAsync()
        {
            //1.d HttpService-en kerszetül backend hívás
            List<Subject>  subjects= await _httpService.GetAllAsync();
        }
    }
}
