using System;
using System.Linq;

namespace ValueConversions
{
    public class Program
    {
        private static void Main()
        {
            var db = new ValueConversionsContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Console.Clear();

            db.BeTrues.Add(new BeTrue
            {
                DaNe = true,
                Dn = true,
                JaNein = true,
                Jn = true,
                MyOwnTruth = true,
                OneMinusOne = true,
                TrueFalse = true,
                YesNo = true,
                Yn = true
            });

            db.SaveChanges();

            Console.ReadLine();

            db.BeTrues.Where(beTrue =>
                    beTrue.DaNe ||
                    beTrue.Dn ||
                    beTrue.JaNein ||
                    beTrue.Jn ||
                    !beTrue.MyOwnTruth ||
                    !beTrue.OneMinusOne ||
                    !beTrue.TrueFalse ||
                    !beTrue.YesNo ||
                    !beTrue.Yn
                )
                .ToList();

            Console.ReadLine();

            foreach (var beTrue in db.BeTrues.ToList())
                Console.WriteLine(beTrue.MyOwnTruth);

            Console.ReadLine();
        }
    }
}
