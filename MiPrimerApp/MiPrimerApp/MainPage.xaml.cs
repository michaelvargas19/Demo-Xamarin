using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiPrimerApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void btnCalculadora_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calculadora());
        }

        private async void btnRest_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rest());
        }

        private async void btnCamara_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Camara());
        }

        private void btnPerfil_Clicked(object sender, EventArgs e)
        {

        }
    }
}
