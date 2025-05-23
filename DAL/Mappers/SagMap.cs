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
    public static class SagMap
    {
        public static DTOSag Map(DALSag dal)
        {
            if (dal == null) return null;

            return new DTOSag(dal.SagsNr, dal.Overskrift, dal.Beskrivelse, dal.AfdelingNummer);
        }

        public static DALSag Map(DTOSag dto)
        {
            if (dto == null) return null;

            return new DALSag
            {
                SagsNr = dto.SagsNr,
                Overskrift = dto.Overskrift,
                Beskrivelse = dto.Beskrivelse,
                AfdelingNummer = dto.AfdelingNummer
            };
        }
    }
}
