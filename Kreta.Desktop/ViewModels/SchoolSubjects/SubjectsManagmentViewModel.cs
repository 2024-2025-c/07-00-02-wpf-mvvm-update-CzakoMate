using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;

namespace Kreta.Desktop.ViewModels.SchoolSubjects
{
    public partial class SubjectsManagmentViewModel : BaseViewModel
    {
        private readonly ISubjectHttpService _httpService;

        //1.feladat: tantárgyak lekérése a backendről (vizsgaremek)
        //1.a Adatok menüpont kiválasztására jelenjenek meg: InitializeAsync
    }
}
