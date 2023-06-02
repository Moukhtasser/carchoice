using System.ComponentModel.DataAnnotations;

namespace testPFA.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public Loueur Loueur { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
