using System;
using Xamarin.Forms;

namespace FormsRevealer.Sample.Pages
{
    public partial class CentralReveal : ContentPage
    {

        private bool _revealing = false;
        public CentralReveal()
        {
            InitializeComponent();
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (_revealing)
            {
                CentralRevealer.StartHidingAnimation();
            }
            else
            {
                CentralRevealer.StartRevealAnimation();
            }

            _revealing = !_revealing;
        }
    }
}
