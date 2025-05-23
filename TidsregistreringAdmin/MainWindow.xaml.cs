using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.BLLModels;
using DTO.DTOModels;

namespace TidsregistreringAdmin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadAfdelinger();
            LoadMedarbejdere();
            LoadSager();
        }

        private void LoadAfdelinger()
        {
            var afdelinger = BLLAfdeling.HentAlleAfdelinger();
            AfdelingListBox.ItemsSource = afdelinger;
            AfdelingCombo.ItemsSource = afdelinger;
        }

        private void LoadMedarbejdere()
        {
            var medarbejdere = BLLMedarbejder.HentAlleMedarbejdere();
            MedarbejderListBox.ItemsSource = medarbejdere;
        }

        private void LoadSager()
        {
            var sager = BLLSag.HentAlleSager();
            SagListBox.ItemsSource = sager;
        }

        private void AddAfdeling_Click(object sender, RoutedEventArgs e)
        {
            string navn = NyAfdelingNavnBox.Text;
            int nummer;
            if (string.IsNullOrWhiteSpace(navn) || !int.TryParse(NyAfdelingNummerBox.Text, out nummer))
            {
                MessageBox.Show("Udfyld både navn og nummer korrekt.");
                return;
            }

            DTOAfdeling ny = new DTOAfdeling(new System.Collections.Generic.List<DTOMedarbejder>(), navn, nummer);
            BLLAfdeling.OpretAfdeling(ny);

            LoadAfdelinger();
            NyAfdelingNavnBox.Clear();
            NyAfdelingNummerBox.Clear();
        }

        private void AddMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            if (AfdelingCombo.SelectedValue == null) return;

            DTOMedarbejder ny = new DTOMedarbejder(
                InitialerBox.Text,
                CPRBox.Text,
                NavnBox.Text,
                (int)AfdelingCombo.SelectedValue);

            BLLMedarbejder.OpretMedarbejder(ny);
            LoadMedarbejdere();
        }

        private void AddSag_Click(object sender, RoutedEventArgs e)
        {
            if (AfdelingCombo.SelectedValue == null) return;

            int sagsNr;
            if (!int.TryParse(SagsnrBox.Text, out sagsNr)) return;

            DTOSag sag = new DTOSag(
                sagsNr,
                OverskriftBox.Text,
                BeskrivelseBox.Text,
                (int)AfdelingCombo.SelectedValue);

            BLLSag.OpretSag(sag);
            LoadSager();
        }
    }
}

