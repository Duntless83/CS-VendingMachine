using StructureMap;

namespace CS.VendingMachine.DependencyInjection
{
    public class ProjRegistry : Registry
    {
        public ProjRegistry()
        {
            For<IMachine>().Singleton().Use<Machine>();
            For<IBank>().Singleton().Use<Bank>();
        }
    }
}
