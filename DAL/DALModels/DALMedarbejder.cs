using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALModels
{
    public class DALMedarbejder
    {
        [Key]
        public string Initialer { get; set; }
        public string CPR { get; set; }
        public string Navn { get; set; }

        [ForeignKey("Afdeling")]
        public int AfdelingNummer { get; set; }
        public virtual DALAfdeling Afdeling { get; set; }

        public virtual ICollection<DALSag> Sager { get; set; }
        public virtual ICollection<DALRegistrering> Registreringer { get; set; }

        public DALMedarbejder()
        {
            Initialer = string.Empty;
            CPR = string.Empty;
            Navn = string.Empty;
            Sager = new List<DALSag>();
            Registreringer = new List<DALRegistrering>();
        }
    }
}
