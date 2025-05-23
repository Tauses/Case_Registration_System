using DAL.DALModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.DTOModels;

namespace DAL.Mappers
{
    public static class AfdelingMap
    {
        public static DTOAfdeling Map(DALAfdeling dal)
        {
            if (dal == null) return null;

            return new DTOAfdeling
            {
                Nummer = dal.Nummer,
                Navn = dal.Navn,
                DTOMedarbejdere = dal.Medarbejdere != null
                    ? dal.Medarbejdere.Select(MedarbejderMap.Map).ToList()
                    : new List<DTOMedarbejder>()
            };
        }

        public static DALAfdeling Map(DTOAfdeling dto)
        {
            if (dto == null) return null;

            return new DALAfdeling
            {
                Nummer = dto.Nummer,
                Navn = dto.Navn,
                Medarbejdere = dto.DTOMedarbejdere != null
                    ? dto.DTOMedarbejdere.Select(MedarbejderMap.Map).ToList()
                    : new List<DALMedarbejder>()
            };
        }
    }
}
