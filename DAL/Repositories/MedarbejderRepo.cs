using DAL.Mappers;
using DTO.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public static class MedarbejderRepo
    {
        public static DTOMedarbejder Get(string initialer)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                return MedarbejderMap.Map(ctx.Medarbejdere.Find(initialer));
            }
        }

        public static List<DTOMedarbejder> GetAll()
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                return ctx.Medarbejdere.ToList().Select(MedarbejderMap.Map).ToList();
            }
        }

        public static void Create(DTOMedarbejder dto)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                ctx.Medarbejdere.Add(MedarbejderMap.Map(dto));
                ctx.SaveChanges();
            }
        }

        public static void Update(DTOMedarbejder dto)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                var entity = ctx.Medarbejdere.Find(dto.Initialer);
                if (entity != null)
                {
                    entity.Navn = dto.Navn;
                    entity.CPR = dto.CPR;
                    entity.AfdelingNummer = dto.AfdelingNummer;
                    ctx.SaveChanges();
                }
            }
        }

        public static void Delete(string initialer)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                var entity = ctx.Medarbejdere.Find(initialer);
                if (entity != null)
                {
                    ctx.Medarbejdere.Remove(entity);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
