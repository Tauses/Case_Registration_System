using DAL.DALModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Context
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var afdelinger = new List<DALAfdeling>
            {
                new DALAfdeling { Nummer = 1, Navn = "HR" },
                new DALAfdeling { Nummer = 2, Navn = "IT" },
                new DALAfdeling { Nummer = 3, Navn = "Økonomi" }
            };
            afdelinger.ForEach(a => context.Afdelinger.Add(a));

            var medarbejdere = new List<DALMedarbejder>
            {
                new DALMedarbejder { Initialer = "abc", CPR = "123456-7890", Navn = "Anders", AfdelingNummer = 1 },
                new DALMedarbejder { Initialer = "xyz", CPR = "111111-2222", Navn = "Xenia", AfdelingNummer = 2 }
            };
            medarbejdere.ForEach(m => context.Medarbejdere.Add(m));

            var sager = new List<DALSag>
            {
                new DALSag { SagsNr = 100, Overskrift = "Website", Beskrivelse = "Ny hjemmeside", AfdelingNummer = 2 },
                new DALSag { SagsNr = 101, Overskrift = "Budget", Beskrivelse = "2025 Budget", AfdelingNummer = 3 }
            };
            sager.ForEach(s => context.Sager.Add(s));

            context.SaveChanges();
        }
    }
}
