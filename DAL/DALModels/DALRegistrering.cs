using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALModels
{
    public class DALRegistrering
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        [ForeignKey("Medarbejder")]
        public string MedarbejderInitialer { get; set; }
        public virtual DALMedarbejder Medarbejder { get; set; }

        [ForeignKey("Sag")]
        public int? SagNr { get; set; }
        public virtual DALSag Sag { get; set; }

        public DALRegistrering()
        {
            MedarbejderInitialer = string.Empty;
        }
    }
}
