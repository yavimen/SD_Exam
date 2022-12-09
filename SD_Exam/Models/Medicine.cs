using System.ComponentModel.DataAnnotations;

namespace SD_Exam.Models
{
    public class Medicine
    {
        public int ID { get; set; }

        public string Title { get; set; } = null!;

        public double Dose { get; set; }

        public string Description { get; set; } = null!;

        public int Amount { get; set; }
    }
}
