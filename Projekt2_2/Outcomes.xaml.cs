using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Projekt1;

namespace Projekt2_2
{
    /// <summary>
    /// Logika interakcji dla klasy Outcomes.xaml
    /// </summary>
    public partial class Outcomes : Window
    {
        private readonly Guid _personId;
        public OutcomeModel OutcomeModel { get; set; }

        public Outcomes()
        {
            InitializeComponent();
            OutcomeModel = new OutcomeModel();
            DataContext = OutcomeModel;
        }

        public Outcomes(Guid personId) : this()
        {
            _personId = personId;
            RefreshOutcomesGrid();
        }

        private void RefreshOutcomesGrid()
        {
            OutcomesGrid.ItemsSource = ContextFactory.Context.Outcomes.Where(n => n.PersonId == _personId).ToList();
        }

        private void Row_OutcomeClicked(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var outcome = row?.Item as Outcome;
            if (row == null || outcome == null) return;

            OutcomeModel.Name = outcome.Name;
            OutcomeModel.Value = outcome.Value;
            OutcomeModel.Id = outcome.Id;
        }

        private void SaveOutcome(object sender, RoutedEventArgs e)
        {
            var ctx = ContextFactory.Context;
            var outcome = ctx.Outcomes.Single(n => n.Id == OutcomeModel.Id);
            outcome.Name = OutcomeModel.Name;
            outcome.Value = OutcomeModel.Value;
            ctx.Update(outcome);
            ctx.SaveChanges();
            RefreshOutcomesGrid();
        }

        private void AddOutcome(object sender, RoutedEventArgs e)
        {
            var ctx = ContextFactory.Context;
            var outcome = new Outcome
            {
                Name = OutcomeModel.Name,
                Value = OutcomeModel.Value,
                PersonId = _personId
            };
            outcome.Name = OutcomeModel.Name;
            outcome.Value = OutcomeModel.Value;
            ctx.Outcomes.Add(outcome);
            ctx.SaveChanges();
            RefreshOutcomesGrid();
        }

        private void DeleteOutcome(object sender, RoutedEventArgs e)
        {
            var ctx = ContextFactory.Context;
            var outcome = ctx.Outcomes.Single(n => n.Id == OutcomeModel.Id);
            ctx.Remove(outcome);
            ctx.SaveChanges();
            RefreshOutcomesGrid();
        }
    }

    public class OutcomeModel : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;

                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                if (_value == value)
                    return;

                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
