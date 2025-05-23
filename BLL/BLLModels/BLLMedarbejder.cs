using DAL.Repositories;
using DTO.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLLModels
{
    public static class BLLMedarbejder
    {
        public static DTOMedarbejder HentMedarbejder(string initialer) => MedarbejderRepo.Get(initialer);
        public static List<DTOMedarbejder> HentAlleMedarbejdere() => MedarbejderRepo.GetAll();
        public static void OpretMedarbejder(DTOMedarbejder dto) => MedarbejderRepo.Create(dto);
        public static void OpdaterMedarbejder(DTOMedarbejder dto) => MedarbejderRepo.Update(dto);
        public static void SletMedarbejder(string initialer) => MedarbejderRepo.Delete(initialer);
    }
}
