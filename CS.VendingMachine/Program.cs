using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.VendingMachine.DependencyInjection;
using StructureMap;

namespace CS.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var reg = new Container(c => { c.AddRegistry<ProjRegistry>(); });

            var machine = reg.GetInstance<IMachine>();

            var purchaseResult = machine.BuyCan(123456789, 0000);

            var purchaseTask1 = Task.Run(() => machine.BuyCan(123456789, 0000));
            var purchaseTask2 = Task.Run(() => machine.BuyCan(123456789, 0000));
            var purchaseTask3= Task.Run(() => machine.BuyCan(123456789, 0001));

            Console.ReadLine();
        }
    }
}
