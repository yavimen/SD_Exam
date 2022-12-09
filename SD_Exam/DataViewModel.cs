using System.Collections.ObjectModel;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows.Input;
using SD_Exam.Models;

namespace SD_Exam
{
    public class DataViewModel: ViewModelBase
    {
        public MedicineContext _dbContext;

        public DataViewModel()
        {
        }

        protected ObservableCollection<Medicine> _medicines { get; set; }
        public ObservableCollection<Medicine> Medicines
        {
            get { return _medicines; }
            set
            {
                _medicines = value;
                OnPropertyChanged("Medicines");
            }
        }

        private Medicine _selectedMedicine;

        public Medicine SelectedMedicine
        {
            get { return _selectedMedicine; }
            set
            {
                _selectedMedicine = value;
                OnPropertyChanged("SelectedMedicine");
            }
        }
    }
}
