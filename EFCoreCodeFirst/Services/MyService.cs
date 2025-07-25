using System.Diagnostics.Metrics;

namespace EFCoreCodeFirst.Services
{
    public class MyService : IMyService
    {
        private static int _counter = 0;

        public MyService() 
        {
            _counter++;
        }

        public int InstanceCount
        {
            get
            {
                return _counter;
            }
        }
    }
}
