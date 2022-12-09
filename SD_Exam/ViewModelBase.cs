using System.ComponentModel;

namespace SD_Exam
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) 
        {
            PropertyChangedEventHandler? handler = PropertyChanged;

            if (handler != null) 
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
