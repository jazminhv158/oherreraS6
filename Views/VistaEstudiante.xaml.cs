using Newtonsoft.Json;
using oherreraS6.Models;
using System.Collections.ObjectModel;

namespace oherreraS6.Views;

public partial class VistaEstudiante : ContentPage
{
	//crear variable
	private const string URL = "http://192.168.10.213/moviles/wsestudiante.php";  //cambiar la ip por la de la maquina o cel
	//crear metodo http client
	private readonly HttpClient cliente = new HttpClient();
	//crear el paquete
	private ObservableCollection <Estudiante> _Estudiantes;

	public async void mostrar()
	{
		var content = await cliente.GetStringAsync(URL); 
        List<Estudiante> lista =
        JsonConvert.DeserializeObject<List<Estudiante>>(content);
        _Estudiantes = new ObservableCollection<Estudiante>(lista);
		lvEstudiantes.ItemsSource = lista;
			// se desepaqueta el json que llego
	}

    public VistaEstudiante()
	{
		InitializeComponent();
		mostrar();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        mostrar();   // <<<<< Se recarga la lista siempre que regreses a esta vista
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        //se va a activar la otra vista
        Navigation.PushAsync(new Views.vistaAgregar());

    }



    private void lvEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var estudiante = e.CurrentSelection.FirstOrDefault() as Estudiante;

        if (estudiante == null)
            return;

        Navigation.PushAsync(new Views.vistaActElim(estudiante));

        lvEstudiantes.SelectedItem = null;

    }
}