using System.ComponentModel.DataAnnotations;

namespace testPFA.Models
{
    public class Saison
    {
        [Key]
        public int IdSaison { get; set; }
        public string Nom { get; set; }
        public List<Reservation> Reservations { get; set; }
    }

}
