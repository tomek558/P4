using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Projekt2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var p = ContextFactory.Context.Person.ToList();
            PeopleGrid.ItemsSource = p;
        }

        private void GoToOutcomes(object sender, RoutedEventArgs e)
        {
            var personId = ((Button)sender).CommandParameter as Guid? ?? null;
            var w = new Outcomes(personId.Value);
            w.Show();
        }

        private void GoToIncomes(object sender, RoutedEventArgs e)
        {
            var personId = ((Button)sender).CommandParameter as Guid? ?? null;
            var w = new Incomes(personId.Value);
            w.Show();
        }
    }
}
