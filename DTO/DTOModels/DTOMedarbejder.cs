using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOModels
{
    public class DTOMedarbejder
    {
        public string Initialer { get; set; } = string.Empty;   // automatisk initialisering, for at undgå null referencer
        public string CPR { get; set; } = string.Empty;
        public string Navn { get; set; } = string.Empty;
        public int AfdelingNummer { get; set; }

        public DTOMedarbejder() { }

        public DTOMedarbejder(string initialer, string cpr, string navn, int afdelingNummer)
        {
            Initialer = initialer;
            CPR = cpr;
            Navn = navn;
            AfdelingNummer = afdelingNummer;
        }
    }
}
