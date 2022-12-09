using SD_Exam.Models;
using System;
using System.Linq;
using System.Windows;

namespace SD_Exam
{
    /// <summary>
    /// Interaction logic for AdditionalWindow.xaml
    /// </summary>
    public partial class AdditionalWindow : Window
    {
        protected DataViewModel viewModel;
        public AdditionalWindow(DataViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void AddMedicine_Click(object sender, RoutedEventArgs e)
        {
            Medicine newMedicine;
            try{
                newMedicine = new Medicine {
                    Title = TitleText.Text,
                    Description = DescrText.Text,
                    Dose = Double.Parse(DoseText.Text),
                    Amount = int.Parse(AmountText.Text)
                };
            }
            catch(Exception) { return; }

            if(newMedicine.Title != null && newMedicine.Title.Length < 50
                && newMedicine.Description != null && newMedicine.Description.Length < 100
                && newMedicine.Amount > 0 && newMedicine.Dose > 0) 
            {
                viewModel._dbContext.Add(newMedicine);
                viewModel._dbContext.SaveChanges();
                viewModel.Medicines.Add(newMedicine);
            }
            this.Close();
        }
    }
}
