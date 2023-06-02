using System.ComponentModel.DataAnnotations;

namespace testPFA.Models
{
    public class Loueur
    {
        [Key]
        public int IdLoueur { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public List<Client> Clients { get; set; }
    }





   
}
