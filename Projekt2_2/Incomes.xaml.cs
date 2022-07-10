using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Projekt1;

namespace Projekt2_2
{
    /// <summary>
    /// Logika interakcji dla klasy Outcomes.xaml
    /// </summary>
    public partial class Incomes : Window
    {
        private readonly Guid _personId;
        public IncomeModel IncomeModel { get; set; }

        public Incomes()
        {
            InitializeComponent();
            IncomeModel = new IncomeModel();
            DataContext = IncomeModel;
        }

        public Incomes(Guid personId) : this()
        {
            _personId = personId;
            RefreshIncomesGrid();
        }

        private void RefreshIncomesGrid()
        {
            IncomesGrid.ItemsSource = ContextFactory.Context.Incomes.Where(n => n.PersonId == _personId).ToList();
        }

        private void Row_IncomeClicked(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var income = row?.Item as Income;
            if (row == null || income == null) return;

            IncomeModel.Name = income.Name;
            IncomeModel.Value = income.Value;
            IncomeModel.Id = income.Id;
        }

        private void SaveIncome(object sender, RoutedEventArgs e)
        {
            var ctx = ContextFactory.Context;
            var income = ctx.Incomes.Single(n => n.Id == IncomeModel.Id);
            income.Name = IncomeModel.Name;
            income.Value = IncomeModel.Value;
            ctx.Update(income);
            ctx.SaveChanges();
            RefreshIncomesGrid();
        }

        private void AddIncome(object sender, RoutedEventArgs e)
        {
            var ctx = ContextFactory.Context;
            var income = new Income
            {
                Name = IncomeModel.Name,
                Value = IncomeModel.Value,
                PersonId = _personId
            };
            income.Name = IncomeModel.Name;
            income.Value = IncomeModel.Value;
            ctx.Incomes.Add(income);
            ctx.SaveChanges();
            RefreshIncomesGrid();
        }

        private void DeleteIncome(object sender, RoutedEventArgs e)
        {
            var ctx = ContextFactory.Context;
            var income = ctx.Incomes.Single(n => n.Id == IncomeModel.Id);
            ctx.Remove(income);
            ctx.SaveChanges();
            RefreshIncomesGrid();
        }
    }

    public class IncomeModel : INotifyPropertyChanged
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

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
