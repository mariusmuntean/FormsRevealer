using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FormsRevealer.Sample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void RevealLogin_Clicked(object sender, EventArgs e)
        {
            LoginRevealer.StartRevealAnimation();
        }

        void HideLogin_Clicked(object sender, EventArgs e)
        {
            LoginRevealer.StartHidingAnimation();
        }

        void RevealRegister_Clicked(object sender, EventArgs e)
        {
            RegisterRevealer.StartRevealAnimation();
        }

        void HideRegister_Clicked(object sender, EventArgs e)
        {
            RegisterRevealer.StartRevealAnimation();
        }

    }
}
