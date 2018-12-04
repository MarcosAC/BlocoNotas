using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlocoNotas.Services
{
    public class NavigationService : INavigationService
    {                
        public async Task PushAsync(Page page) => await App.Current.MainPage.Navigation.PushAsync(page);
        public async Task PushModalAsync(Page page) => await App.Current.MainPage.Navigation.PushModalAsync(page);
        public async Task PopAsync() => await App.Current.MainPage.Navigation.PopAsync();
        public async Task PopModalAsync() => await App.Current.MainPage.Navigation.PopModalAsync();        
    }
}
