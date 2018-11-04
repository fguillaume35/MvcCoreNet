using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreNet.Models
{
    public class Lib
    {
        [Key]
        public int IdLib { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public int? IdCategorie { get; set; }
        public Categorie Categorie { get; set; }
        public ICollection<Lien> Lien { get; set; }
    }

    public class Categorie
    {
        [Key]
        public int IdCategorie { get; set; }
        public string Nom { get; set; }
        public bool Tag { get; set; }
        public ICollection<Lib> Etudiants { get; set; }
    }

    public class Lien
    {
        [Key]
        public int IdLien { get; set; }
        public string Intitule { get; set; }
        public string Url { get; set; }
        public int IdLib { get; set; }
    }

    public class Hebergement
    {
        [Key]
        public int IdHebergement { get; set; }
        public string Intitule { get; set; }
        public string Url { get; set; }
        public int IdLib { get; set; }
    }
}
