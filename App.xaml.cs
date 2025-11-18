namespace oherreraS6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // se habilita la navegacion de la otra/s vistas
            return new Window(new NavigationPage(new Views.VistaEstudiante()));
        }
    }
}