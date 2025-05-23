using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALModels
{
    public class DALSag
    {
        [Key]
        public int SagsNr { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }

        [ForeignKey("Afdeling")]
        public int AfdelingNummer { get; set; }
        public virtual DALAfdeling Afdeling { get; set; }

        public virtual ICollection<DALRegistrering> Registreringer { get; set; }

        public DALSag()
        {
            Overskrift = string.Empty;
            Beskrivelse = string.Empty;
            Registreringer = new List<DALRegistrering>();
        }
    }
}
