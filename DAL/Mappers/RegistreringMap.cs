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
    public static class RegistreringMap
    {
        public static DTORegistrering Map(DALRegistrering dal)
        {
            if (dal == null) return null;

            return new DTORegistrering(dal.Id, dal.MedarbejderInitialer, dal.SagNr, dal.StartTid, dal.SlutTid);
        }

        public static DALRegistrering Map(DTORegistrering dto)
        {
            if (dto == null) return null;

            return new DALRegistrering
            {
                Id = dto.Id,
                MedarbejderInitialer = dto.MedarbejderInitialer,
                SagNr = dto.SagNr,
                StartTid = dto.StartTid,
                SlutTid = dto.SlutTid
            };
        }
    }
}

