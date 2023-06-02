using System.ComponentModel.DataAnnotations;

namespace testPFA.Models
{
    public class ModeleDeVoiture
    {
        [Key]
        public int IdModele { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
    }
}
