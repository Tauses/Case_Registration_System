using DAL.Mappers;
using DTO.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public static class RegistreringRepo
    {
        public static DTORegistrering Get(int id)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                return RegistreringMap.Map(ctx.Registreringer.Find(id));
            }
        }

        public static List<DTORegistrering> GetAll()
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                return ctx.Registreringer.ToList().Select(RegistreringMap.Map).ToList();
            }
        }

        public static void Create(DTORegistrering dto)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                ctx.Registreringer.Add(RegistreringMap.Map(dto));
                ctx.SaveChanges();
            }
        }

        public static void Update(DTORegistrering dto)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                var entity = ctx.Registreringer.Find(dto.Id);
                if (entity != null)
                {
                    entity.StartTid = dto.StartTid;
                    entity.SlutTid = dto.SlutTid;
                    entity.MedarbejderInitialer = dto.MedarbejderInitialer;
                    entity.SagNr = dto.SagNr;
                    ctx.SaveChanges();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                var entity = ctx.Registreringer.Find(id);
                if (entity != null)
                {
                    ctx.Registreringer.Remove(entity);
                    ctx.SaveChanges();
                }
            }
        }
    }

}


