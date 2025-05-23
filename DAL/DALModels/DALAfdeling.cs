using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALModels
{
    public class DALAfdeling
    {
        [Key]
        public int Nummer { get; set; }
        public string Navn { get; set; }

        public virtual ICollection<DALMedarbejder> Medarbejdere { get; set; }
        public virtual ICollection<DALSag> Sager { get; set; }

        public DALAfdeling()
        {
            Navn = string.Empty;
            Medarbejdere = new List<DALMedarbejder>();
            Sager = new List<DALSag>();
        }
    }
}

