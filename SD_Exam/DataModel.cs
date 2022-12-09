using SD_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Exam
{
    public class DataModel
    {
        public MedicineContext _dbContext;
        public IEnumerable<Medicine> Medicines { get; set; }
        public DataModel()
        {

        }
        public DataModel(MedicineContext dbContext)
        {
            _dbContext = dbContext;
            Medicines = dbContext.Medicines;
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
