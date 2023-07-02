using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testPFA.Models
{
    public class Reservation
    {
        [Key]
        public int IdReservation { get; set; }
        public Client Client { get; set; }
        public ModeleDeVoiture Voiture { get; set; }
        public List<Extra> Extras { get; set; }
        [ForeignKey("IdSaison")]
        public Saison Saison { get; set; }
        public double PrixR { get; set; }

    }
}
