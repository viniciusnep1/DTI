using services.services.calc;
using services.services.calculos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IHostedServiceSample
{
    public class DataRefreshService : HostedService
    {
        private readonly QueryVolumes query;

        public DataRefreshService(QueryVolumes query)
        {
            this.query=query;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await query.InserValues();
                await Task.Delay(TimeSpan.FromMinutes(30), cancellationToken);
            }
        }
    }
}
