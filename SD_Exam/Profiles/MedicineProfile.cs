using AutoMapper;
using SD_Exam.Models;

namespace SD_Exam.Profiles
{
    public class MedicineProfile:Profile
    {
        public MedicineProfile()
        {
            CreateMap<DataModel, DataViewModel>()
                .ReverseMap();
        }
    }
}
