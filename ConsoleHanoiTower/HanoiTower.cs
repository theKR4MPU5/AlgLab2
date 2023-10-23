using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHanoiTower
{
    public class HanoiTower : Enumeration
    {
        public HanoiTower() : base(0, "HanoiTower")
        {
        }

        public override void AlgRun(int[] array, int numberOfDisks)
        {
            SolveHanoiTower(numberOfDisks, 'A', 'B', 'C');
        }

        private void SolveHanoiTower(int n, char source, char auxiliary, char target)
        {
            if (n == 1)
            {
                //Console.WriteLine($"Move disk 1 from {source} to {target}");
                return;
            }

            SolveHanoiTower(n - 1, source, target, auxiliary);
            //Console.WriteLine($"Move disk {n} from {source} to {target}");
            SolveHanoiTower(n - 1, auxiliary, source, target);
        }
    }
}
