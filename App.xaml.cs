using lopezgSA2.Views;

namespace lopezgSA2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new lopezgSA2.Views.login()));
        }
    }
}