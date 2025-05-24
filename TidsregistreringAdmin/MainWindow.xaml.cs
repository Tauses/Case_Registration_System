// MainWindow.xaml.cs med AddAfdeling_Click, visuelle timer og CRUD-funktioner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DTO.DTOModels;
using BLL;
using BLL.BLLModels;

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

            DTOAfdeling ny = new DTOAfdeling(new List<DTOMedarbejder>(), navn, nummer);
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

        private void MedarbejderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var valgt = MedarbejderListBox.SelectedItem as DTOMedarbejder;
            if (valgt == null) return;

            var registreringer = BLLRegistrering.HentAlleRegistreringer()
                .Where(r => r.MedarbejderInitialer == valgt.Initialer)
                .ToList();

            var ugeStart = StartOfWeek(DateTime.Now);
            var månedStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            double timerUge = registreringer
                .Where(r => r.StartTid >= ugeStart && r.StartTid < ugeStart.AddDays(7))
                .Sum(r => (r.SlutTid - r.StartTid).TotalHours);

            double timerMåned = registreringer
                .Where(r => r.StartTid >= månedStart && r.StartTid < månedStart.AddMonths(1))
                .Sum(r => (r.SlutTid - r.StartTid).TotalHours);

            double totalTimer = registreringer.Sum(r => (r.SlutTid - r.StartTid).TotalHours);

            // Vis timer i visuelle felter i stedet for popup
            UgeTimerText.Text = $"Uge: {timerUge:0.00} timer";
            MånedTimerText.Text = $"Måned: {timerMåned:0.00} timer";
            TotalTimerText.Text = $"Total: {totalTimer:0.00} timer";
        }

        private DateTime StartOfWeek(DateTime dt)
        {
            var diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
