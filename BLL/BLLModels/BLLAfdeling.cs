using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DTO.DTOModels;


namespace BLL.BLLModels
{
    public static class BLLAfdeling
    {
        public static DTOAfdeling HentAfdeling(int id) => AfdelingRepo.Get(id);
        public static List<DTOAfdeling> HentAlleAfdelinger() => AfdelingRepo.GetAll();
        public static void OpretAfdeling(DTOAfdeling dto) => AfdelingRepo.Create(dto);
        public static void OpdaterAfdeling(DTOAfdeling dto) => AfdelingRepo.Update(dto);
        public static void SletAfdeling(int id) => AfdelingRepo.Delete(id);
    }
}
