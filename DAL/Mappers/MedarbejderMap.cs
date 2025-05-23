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
    public static class MedarbejderMap
    {
        public static DTOMedarbejder Map(DALMedarbejder dal)
        {
            if (dal == null) return null;

            return new DTOMedarbejder(dal.Initialer, dal.CPR, dal.Navn, dal.AfdelingNummer);
        }

        public static DALMedarbejder Map(DTOMedarbejder dto)
        {
            if (dto == null) return null;

            return new DALMedarbejder
            {
                Initialer = dto.Initialer,
                CPR = dto.CPR,
                Navn = dto.Navn,
                AfdelingNummer = dto.AfdelingNummer
            };
        }
    }
}

