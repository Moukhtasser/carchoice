using System.ComponentModel.DataAnnotations;

namespace testPFA.Models
{
    public class Extra
    {
        [Key]
        public int IdExtra { get; set; }
        public string NomExtra { get; set; }
        public double Prix { get; set; }
        public Reservation Reservation { get; set; }
    }
}
