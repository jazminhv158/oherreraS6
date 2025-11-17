using Newtonsoft.Json;
using oherreraS6.Models;
using System.Collections.ObjectModel;

namespace oherreraS6.Views;

public partial class VistaEstudiante : ContentPage
{
	//crear variable
	private const string URL = "10.2.15.44/moviles/wsestudiante.php";  //cambiar la ip por la de la maquina o cel
	//crear metodo http client
	private readonly HttpClient cliente = new HttpClient();
	//crear el paquete
	private ObservableCollection <Estudiante> _Estudiantes;

	public async void mostrar()
	{
		var content = await cliente.GetStringAsync(URL); //metodo get
		List<Estudiante> lista = new JsonConvert.DeserializeObject<List<Estudiante>>(content);
		_Estudiantes = new ObservableCollection<Estudiante>(lista);
		lvEstudiantes.ItemsSource = lista;
			// se desepaqueta el json que llego
	}

    public VistaEstudiante()
	{
		InitializeComponent();
	}
}