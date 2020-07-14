using System;
using System.Linq;
using ValueConversions;

namespace EntityFrameworkCoreHiddenGems
{
    public partial class Program
    {
        private static void Main()
        {
            var context = new ValueConversionsContext();
            CreateDatabase(context);

            Console.Clear();

            DisplayDemoStep("Add a new be true to the database");

            context.BeTrues.Add(new BeTrue
            {
                DaNe = true,
                Dn = true,
                JaNein = true,
                Jn = true,
                MyOwnTruth = true,
                HisOwnTruth = true,
                HerOwnTruth = true,
                OneMinusOne = true,
                TrueFalse = true,
                YesNo = true,
                Yn = true,
                SiNo = true,
                Sn = true
            });

            context.SaveChanges();

            Console.ReadLine();

            DisplayDemoStep("Get some be trues from the database");

            context.BeTrues.Where(beTrue =>
                    beTrue.DaNe ||
                    beTrue.Dn ||
                    beTrue.JaNein ||
                    beTrue.Jn ||
                    !beTrue.MyOwnTruth ||
                    !beTrue.HisOwnTruth ||
                    !beTrue.HerOwnTruth ||
                    !beTrue.OneMinusOne ||
                    !beTrue.TrueFalse ||
                    !beTrue.YesNo ||
                    !beTrue.Yn ||
                    !beTrue.SiNo ||
                    !beTrue.Sn
                )
                .ToList();

            Console.ReadLine();

            DisplayDemoStep("Get all be trues from the database");

            foreach (var beTrue in context.BeTrues.ToList())
                Console.WriteLine(beTrue.MyOwnTruth);
        }
    }
}
