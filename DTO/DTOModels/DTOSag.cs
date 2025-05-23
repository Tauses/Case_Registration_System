using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOModels
{
    public class DTOSag
    {
        public int SagsNr { get; set; }
        public string Overskrift { get; set; } = string.Empty;
        public string Beskrivelse { get; set; } = string.Empty;
        public int AfdelingNummer { get; set; }

        public DTOSag() { }

        public DTOSag(int sagsNr, string overskrift, string beskrivelse, int afdelingNummer)
        {
            SagsNr = sagsNr;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            AfdelingNummer = afdelingNummer;
        }
    }
}
