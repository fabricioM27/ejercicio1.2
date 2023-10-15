using ejercicio1._2.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.RegularExpressions;

namespace ejercicio1._2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }



        private async void btndatos_Clicked(object sender, EventArgs e)
        {
            var corre = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (string.IsNullOrWhiteSpace(txtnombres.Text) || string.IsNullOrWhiteSpace(txtapellidos.Text) || string.IsNullOrWhiteSpace(txtcorreo.Text) || !corre.IsMatch(txtcorreo.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios, Recuerda ingresar BIEN TU CORREO", "Aceptar");
            }
            else
            {

                var empleados = new Models.Empleados
                {
                    nombre = txtnombres.Text,
                    apellido = txtapellidos.Text,
                    fechanac = txtfechanac.Date.Year + "/" + txtfechanac.Date.Month + "/" + txtfechanac.Date.Day,
                    correo = txtcorreo.Text
                };

                var resultPage = new ResultPage();
                resultPage.BindingContext = empleados;
                await Navigation.PushAsync(resultPage);

                txtnombres.Text = "";
                txtapellidos.Text = "";
                txtcorreo.Text = "";


            }
        }
    }
}