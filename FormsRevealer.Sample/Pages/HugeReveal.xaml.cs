using Xamarin.Forms;

namespace FormsRevealer.Sample.Pages
{
    public partial class HugeReveal : ContentPage
    {
        private bool _revealing = false;
        public HugeReveal()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (_revealing)
            {
                Revealer.StartHidingAnimation();
            }
            else
            {
                Revealer.StartRevealAnimation();
            }


            _revealing = !_revealing;


            _ = btn.RotateTo(720, length: 850, easing: Easing.CubicOut)
                .ContinueWith(t => btn.Rotation = 0.0);
                //.ContinueWith(t => LabelRevealer.StartRevealAnimation());

            btn.Animate("OpacityAnimation", d =>
            {
                if (d < 0.5)
                {
                    btn.Opacity = 1.0 - d;
                }
                else
                {
                    btn.Opacity = d;
                    btn.BackgroundColor = _revealing ? Color.White : Color.DodgerBlue;
                }
            }, length: 600);

        }
    }
}