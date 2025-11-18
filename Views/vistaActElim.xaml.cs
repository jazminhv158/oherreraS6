using oherreraS6.Models;

namespace oherreraS6.Views;

public partial class vistaActElim : ContentPage

{
	public vistaActElim(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombres;
        txtApellido.Text = datos.apellidos;
        txtEdad.Text= datos.edad.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string url = $"http://192.168.10.213/moviles/wsestudiante.php" +
                $"?codigo={txtCodigo.Text}" +
                $"&nombres={txtNombre.Text}" +
                $"&apellidos={txtApellido.Text}" +
                $"&edad={txtEdad.Text}";

            var cliente = new HttpClient();
            var content = new StringContent(""); // cuerpo vacío

            var response = await cliente.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Estudiante actualizado correctamente", "OK");
                await Navigation.PopAsync(); // Regresa a la lista
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }

    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert(
       "Confirmar",
       "¿Está seguro de eliminar este estudiante?",
       "Sí", "No");

        if (!confirmar)
            return;

        try
        {
            string url = $"http://192.168.10.213/moviles/wsestudiante.php?codigo={txtCodigo.Text}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url)
            };

            var cliente = new HttpClient();
            var response = await cliente.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Estudiante eliminado correctamente", "OK");
                await Navigation.PopAsync(); // vuelve a la lista
            }
            else
            {
                await DisplayAlert("Error", "No se pudo eliminar", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }

    }
}