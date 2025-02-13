using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.Base
{
    public  abstract class BaseViewModel : ObservableObject
    {
        //virtual: a metódus felülírható
        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
