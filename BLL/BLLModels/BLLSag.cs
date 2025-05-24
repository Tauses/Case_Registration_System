using DAL.Repositories;
using DTO.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLLModels
{
    public static class BLLSag 
    {
        public static DTOSag HentSag(int sagsNr) => SagRepo.Get(sagsNr);
        public static List<DTOSag> HentAlleSager() => SagRepo.GetAll();
        public static void OpretSag(DTOSag dto) => SagRepo.Create(dto);
        public static void OpdaterSag(DTOSag dto) => SagRepo.Update(dto);
        public static void SletSag(int sagsNr) => SagRepo.Delete(sagsNr);
    }
}
