using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FormsRevealer.Sample.Annotations;
using Xamarin.Forms;

namespace FormsRevealer.Sample.ViewModels
{
    public class LoginRegisterViewModel : INotifyPropertyChanged
    {
        private string _loginButtonText;
        private string _registerButtonText;
        private bool _shouldRevealLogin;
        private bool _shouldRevealRegister;
        public event PropertyChangedEventHandler PropertyChanged;


        public LoginRegisterViewModel()
        {
            RevealHideLoginCommand = new Command(RevealHideLogin);
            RevealHideRegisterCommand = new Command(RevealHideRegister);
            
            LoginButtonText = ShouldRevealLogin ? "Hide Login" : "Reveal Login";
            RegisterButtonText = ShouldRevealRegister ? "Hide Register" : "Reveal Register";
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string LoginButtonText
        {
            get => _loginButtonText;
            set
            {
                _loginButtonText = value;
                OnPropertyChanged();
            }
        }

        public string RegisterButtonText
        {
            get => _registerButtonText;
            set
            {
                _registerButtonText = value;
                OnPropertyChanged();
            }
        }

        public bool ShouldRevealLogin
        {
            get => _shouldRevealLogin;
            set
            {
                _shouldRevealLogin = value;
                OnPropertyChanged();
            }
        }

        public bool ShouldRevealRegister
        {
            get => _shouldRevealRegister;
            set
            {
                _shouldRevealRegister = value;
                OnPropertyChanged();
            }
        }

        public ICommand RevealHideLoginCommand { get; set; }
        public ICommand RevealHideRegisterCommand { get; set; }

        private void RevealHideLogin(object obj)
        {
            ShouldRevealLogin = !ShouldRevealLogin;
            LoginButtonText = ShouldRevealLogin ? "Hide Login" : "Reveal Login";
        }

        private void RevealHideRegister(object obj)
        {
            ShouldRevealRegister = !ShouldRevealRegister;
            RegisterButtonText = ShouldRevealRegister ? "Hide Register" : "Reveal Register";
        }
    }
}