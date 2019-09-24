using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace PrismConfirmNavigation
{
    public class MainPageViewModel : IConfirmNavigationAsync
    {
        private readonly INavigationService navigationService;
        private readonly IPageDialogService pageDialogService;

        public Command NavigateCommand { get; }

        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService)
        {
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;

            NavigateCommand = new Command(async () =>
            {
                var navigationResult = await this.navigationService.NavigateAsync("SecondPage");

                await this.pageDialogService.DisplayAlertAsync("Navigation Result", navigationResult.Success.ToString(), "OK");
            });
        }

        public async Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return await pageDialogService.DisplayAlertAsync("Confirm Navigation", "CanNavigate?", "Yes", "No");
        }
    }
}
