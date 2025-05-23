using DAL.Repositories;
using DTO.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLLModels
{
    public static class BLLRegistrering
    {
        public static DTORegistrering HentRegistrering(int id) => RegistreringRepo.Get(id);
        public static List<DTORegistrering> HentAlleRegistreringer() => RegistreringRepo.GetAll();
        public static void OpretRegistrering(DTORegistrering dto) => RegistreringRepo.Create(dto);
        public static void OpdaterRegistrering(DTORegistrering dto) => RegistreringRepo.Update(dto);
        public static void SletRegistrering(int id) => RegistreringRepo.Delete(id);
    }
}
