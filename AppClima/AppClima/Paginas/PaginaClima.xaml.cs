using AppClima.Servicios;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppClima.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaClima : ContentPage
    {
        public PaginaClima()
        {
            InitializeComponent();
        }

        private void ActualizarActivityIndicator(bool estado)
        {
            activityIndicator.IsRunning = estado;
            activityIndicator.IsEnabled = estado;
            activityIndicator.IsVisible = estado;
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            ActualizarActivityIndicator(true);
            string ciudad = txtCiudad.Text;

            if (!String.IsNullOrEmpty(ciudad))
            {
                var clima = await ServicioClima.ConsultarClima(ciudad);
                this.BindingContext = clima;
            }
            else
                await DisplayAlert("Error", "Debes escribir una ciudad", "OK");

            ActualizarActivityIndicator(false);
        }
    }
}