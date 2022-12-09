using AutoMapper;
using SD_Exam.Models;
using SD_Exam.Profiles;
using System.Windows;

namespace SD_Exam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected Window mainWindow;
        protected DataModel _dataModel;
        protected DataViewModel _dataViewModel;
        protected IMapper _mapper;
        protected MainWindow _mainWindow;
        public App()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MedicineProfile>();
            });
            _mapper = new Mapper(configuration);
            _dataModel = new DataModel(new MedicineContext());
            _dataViewModel = _mapper.Map<DataModel, DataViewModel>(_dataModel);
            _mainWindow = new MainWindow() { DataContext = _dataViewModel };
            _mainWindow.Show();
        }
    }
}
