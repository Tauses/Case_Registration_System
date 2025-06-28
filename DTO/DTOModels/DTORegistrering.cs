using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOModels
{
    public class DTORegistrering
    {
        public int Id { get; set; }
        public string MedarbejderInitialer { get; set; } = string.Empty;
        public int? SagNr { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public DTORegistrering() { }

        public DTORegistrering(int id, string medarbejderInitialer, int? sagNr, DateTime startTid, DateTime slutTid)
        {
            Id = id;
            MedarbejderInitialer = medarbejderInitialer;
            SagNr = sagNr;
            StartTid = startTid;
            SlutTid = slutTid;
        }
    }
}
