using DAL.Mappers;
using DTO.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
        public static class SagRepo
        {
            public static DTOSag Get(int sagsNr)
            {
                using (var ctx = new DAL.Context.DatabaseContext())
                {
                    return SagMap.Map(ctx.Sager.Find(sagsNr));
                }
            }

            public static List<DTOSag> GetAll()
            {
                using (var ctx = new DAL.Context.DatabaseContext())
                {
                    return ctx.Sager.ToList().Select(SagMap.Map).ToList();
                }
            }

            public static void Create(DTOSag dto)
            {
                using (var ctx = new DAL.Context.DatabaseContext())
                {
                    ctx.Sager.Add(SagMap.Map(dto));
                    ctx.SaveChanges();
                }
            }

            public static void Update(DTOSag dto)
            {
                using (var ctx = new DAL.Context.DatabaseContext())
                {
                    var entity = ctx.Sager.Find(dto.SagsNr);
                    if (entity != null)
                    {
                        entity.Overskrift = dto.Overskrift;
                        entity.Beskrivelse = dto.Beskrivelse;
                        entity.AfdelingNummer = dto.AfdelingNummer;
                        ctx.SaveChanges();
                    }
                }
            }

            public static void Delete(int sagsNr)
            {
                using (var ctx = new DAL.Context.DatabaseContext())
                {
                    var entity = ctx.Sager.Find(sagsNr);
                    if (entity != null){
                        ctx.Sager.Remove(entity);
                        ctx.SaveChanges();
                    }
                }
            }
        }
}
