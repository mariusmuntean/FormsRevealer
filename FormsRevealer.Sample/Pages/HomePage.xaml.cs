using Xamarin.Forms;

namespace FormsRevealer.Sample.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void LoginRegisterClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LoginRegisterReveal(), true);
        }

        async void HugeRevealClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new HugeReveal(), true);
        }
    }
}
