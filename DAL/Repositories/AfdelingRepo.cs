using DAL.Mappers;
using DTO.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DAL.Repositories
{
    public static class AfdelingRepo
    {
        public static DTOAfdeling Get(int id)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                return AfdelingMap.Map(ctx.Afdelinger.Find(id));
            }
        }

        public static List<DTOAfdeling> GetAll()
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                var data = ctx.Afdelinger.Include(a => a.Medarbejdere).ToList();  
                return data.Select(AfdelingMap.Map).ToList();
            }
        }

        public static void Create(DTOAfdeling dto)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                ctx.Afdelinger.Add(AfdelingMap.Map(dto));
                ctx.SaveChanges();
            }
        }

        public static void Update(DTOAfdeling dto)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                var entity = ctx.Afdelinger.Find(dto.Nummer);
                if (entity != null)
                {
                    entity.Navn = dto.Navn;
                    ctx.SaveChanges();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var ctx = new DAL.Context.DatabaseContext())
            {
                var entity = ctx.Afdelinger.Find(id);
                if (entity != null)
                {
                    ctx.Afdelinger.Remove(entity);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
