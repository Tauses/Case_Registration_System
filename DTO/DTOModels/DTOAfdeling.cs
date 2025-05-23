using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOModels
{
    public class DTOAfdeling
    {
        public int Nummer { get; set; }
        public string Navn { get; set; }
        public List<DTOMedarbejder> DTOMedarbejdere { get; set; }

        public DTOAfdeling()
        {
            Navn = string.Empty;
            DTOMedarbejdere = new List<DTOMedarbejder>();
        }

        public DTOAfdeling(List<DTOMedarbejder> dtoMedarbejdere, string navn, int nummer)
        {
            DTOMedarbejdere = dtoMedarbejdere ?? new List<DTOMedarbejder>();
            Navn = navn;
            Nummer = nummer;
        }
    }

}
