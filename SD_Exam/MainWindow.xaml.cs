using Microsoft.EntityFrameworkCore;
using SD_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SD_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DeleteMedicine_Click(object sender, RoutedEventArgs e)
        {
                if (((DataViewModel)DataContext).SelectedMedicine!= null && ((DataViewModel)DataContext).SelectedMedicine.ID != 0)
                {
                    var selectedEl = ((DataViewModel)DataContext).SelectedMedicine;
                    ((DataViewModel)DataContext).Medicines
                        .Remove(selectedEl);
                    ((DataViewModel)DataContext)._dbContext.Medicines.Remove(selectedEl);
                    ((DataViewModel)DataContext)._dbContext.SaveChanges();
                }
        }

        private void AddNewMedicine_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AdditionalWindow((DataViewModel)DataContext);
            addWindow.Show();
        }

        private void SellSelected_Click(object sender, RoutedEventArgs e)
        {
            var selected = ((DataViewModel)DataContext).SelectedMedicine;
            if (selected != null && selected.Title != "")
            {
                var dbEnt = ((DataViewModel)DataContext)._dbContext.Medicines.FirstOrDefault(i => i.Title.Equals(selected.Title));
                ((DataViewModel)DataContext).Medicines.FirstOrDefault(i => i.Title.Equals(selected.Title)).Amount -= 1;
                var pos = ((DataViewModel)DataContext).Medicines.IndexOf(selected);
                ((DataViewModel)DataContext).Medicines.Remove(selected);
                ((DataViewModel)DataContext).Medicines.Insert(pos, selected);
                if (selected.Amount == 0)
                {
                    ((DataViewModel)DataContext).Medicines.Remove(selected);
                    ((DataViewModel)DataContext)._dbContext.Medicines.Remove(dbEnt);
                    ((DataViewModel)DataContext)._dbContext.SaveChanges();
                    return;
                }
            ((DataViewModel)DataContext)._dbContext.SaveChanges();
            }
        }

        private void AddOneSelected_Click(object sender, RoutedEventArgs e)
        {
            var selected = ((DataViewModel)DataContext).SelectedMedicine;
            if (selected != null && selected.Title != "")
            {
                var dbEnt = ((DataViewModel)DataContext)._dbContext.Medicines.FirstOrDefault(i => i.Title.Equals(selected.Title));
                ((DataViewModel)DataContext).Medicines.FirstOrDefault(i => i.Title.Equals(selected.Title)).Amount += 1;
                var pos = ((DataViewModel)DataContext).Medicines.IndexOf(selected);
                ((DataViewModel)DataContext).Medicines.Remove(selected);
                ((DataViewModel)DataContext).Medicines.Insert(pos, selected);
                if (selected.Amount == 0)
                {
                    ((DataViewModel)DataContext).Medicines.Remove(selected);
                    ((DataViewModel)DataContext)._dbContext.Medicines.Remove(dbEnt);
                    ((DataViewModel)DataContext)._dbContext.SaveChanges();
                    return;
                }
            ((DataViewModel)DataContext)._dbContext.SaveChanges();
            }
        }
    }
}
