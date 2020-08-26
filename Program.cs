using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ServiceModel;
using ServiceReference;

namespace WSDLDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EndpointAddress endpoint = null;
            endpoint = new EndpointAddress(new Uri("http://www.dneonline.com/calculator.asmx?WSDL"));

            BasicHttpBinding binding = new BasicHttpBinding();            //BasicHttpSecurityMode.Transport
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;//.Basic;

            CalculatorSoapClient calcClient = new CalculatorSoapClient(binding, endpoint);

            Task<int> calculation = calcClient.AddAsync(25, 32);
            calculation.Wait();
            Console.WriteLine(calculation.Result);
            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
