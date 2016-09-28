using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HomeCortana
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        public ApplicationDataContainer dados = null;
        public List<DateTime> horaQuartoLigado = new List<DateTime>();
        public List<DateTime> horaQuartoDesigado = new List<DateTime>();
        public List<DateTime> horaSalaLigado = new List<DateTime>();
        public List<DateTime> horaSalaDesigado = new List<DateTime>();

        private Uri ligaQuato = new Uri("http://192.168.1.2/?pin=LIGA1");
        private Uri desligaQuarto = new Uri("http://192.168.1.2/?pin=DESLIGA1");
        private Uri ligaSala = new Uri("http://192.168.1.2/?pin=LIGA2");
        private Uri desligaSala = new Uri("http://192.168.1.2/?pin=DESLIGA2");

        HttpClient cliente = new HttpClient();

        public Uri LigaQuato
        {
            get
            {
                return ligaQuato;
            }

            set
            {
                ligaQuato = value;
            }
        }

        public Uri DesligaQuarto
        {
            get
            {
                return desligaQuarto;
            }

            set
            {
                desligaQuarto = value;
            }
        }

        public Uri LigaSala
        {
            get
            {
                return ligaSala;
            }

            set
            {
                ligaSala = value;
            }
        }

        public Uri DesligaSala
        {
            get
            {
                return desligaSala;
            }

            set
            {
                desligaSala = value;
            }
        }
        public async void AcessarEndereco(Uri endereco)
        {
            try
            {
                var resultado = await cliente.GetStringAsync(endereco);
            }
            catch (Exception)
            {


            }
        }
        private void tsQuarto_Toggled(object sender, RoutedEventArgs e)
        {
            if (tsQuarto.IsOn)
            {
                AcessarEndereco(LigaQuato);
                horaQuartoLigado.Add(DateTime.Now);
                lblMensagem.Text += "Quarto Ligado: " + horaQuartoLigado.Last() + "\n";
            }
            else
            {
                AcessarEndereco(DesligaQuarto);
                horaQuartoDesigado.Add(DateTime.Now);
                lblMensagem.Text += "Quarto Desligado: " +horaQuartoDesigado.Last() + "\n";
            }     
        }

        private void tsSala_Toggled(object sender, RoutedEventArgs e)
        {
            if (tsSala.IsOn)
            {
                AcessarEndereco(LigaSala);
                horaSalaLigado.Add(DateTime.Now);
                lblMensagem.Text += "Sala Ligado: " + horaSalaLigado.Last() + "\n";
            }
            else
            {
                AcessarEndereco(DesligaSala);
                horaSalaDesigado.Add(DateTime.Now);
                lblMensagem.Text += "Sala Desligado: " + horaSalaDesigado.Last() + "\n";
            }
        }
    }
}
