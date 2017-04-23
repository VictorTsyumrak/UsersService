using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using UsersService;

namespace UsersServiceConsoleHost
{
    public class Program
    {
        private const int Port = 25255;
        private static readonly string Address = $"http://127.0.0.1:{Port}/UsersService";
        public static void Main(string[] args)
        {
            ServiceHost serviceHost = null;
            try
            {
                serviceHost = new ServiceHost(typeof(UsersService.UsersService), new Uri(Address));
                var behavior = new ServiceMetadataBehavior();
                serviceHost.Description.Behaviors.Add(behavior);

                serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                serviceHost.AddServiceEndpoint(typeof(IUsersService), new BasicHttpBinding(), Address);
                serviceHost.Open();

                Console.WriteLine($"Service {nameof(IUsersService)} started @ {DateTime.Now} on {Address}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);   
            }
            finally
            {
                serviceHost?.Close();
            }
        }
    }
}
