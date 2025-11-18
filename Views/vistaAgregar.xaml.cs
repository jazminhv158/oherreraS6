using System.Net;

namespace oherreraS6.Views;

public partial class vistaAgregar : ContentPage
{
	public vistaAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			//objeto por donde se van a enviar los datos
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombres", txtNombre.Text);
			parametros.Add("apellidos", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.10.213/moviles/wsestudiante.php", "POST", parametros);
			DisplayAlert("Alerta", "dato ingresado", "ok");
			Navigation.PushAsync(new Views.VistaEstudiante());

		}
		catch (Exception ex)

		{
			Console.WriteLine("Dato no ingresado" + ex);
		}
		

    }
}