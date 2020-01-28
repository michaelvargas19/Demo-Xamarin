using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculadora : ContentPage
    {
        public Calculadora()
        {
            InitializeComponent();

            //init picker
            Operacion.Items.Add("+");
            Operacion.Items.Add("-");
            Operacion.Items.Add("*");
            Operacion.Items.Add("/");
        }

        private void switchBlack_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                background.BackgroundColor = Color.DarkGray;
            }
            else {
                background.BackgroundColor = Color.White;
            }

        }


        private void resultado_Clicked(object sender, EventArgs e)
        {
            float num1 = float.Parse(n1.Text);
            float num2 = float.Parse(n2.Text);
            var op = Operacion.Items[Operacion.SelectedIndex];


            switch(op)
            {
                case "+":
                    lblResultado.Text = (num1 + num2).ToString();
                    break;

                case "-":
                    lblResultado.Text = (num1 - num2).ToString();
                    break;

                case "*":
                    lblResultado.Text = (num1 * num2).ToString();
                    break;

                case "/":
                    lblResultado.Text = (num1 / num2).ToString();
                    break;
            }
                
        }

        private void Operacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayAlert("Operación", Operacion.Items[Operacion.SelectedIndex], "Aceptar") ;
        }
    }
}