using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.Test.Contracts;
using Zeiss.Test.Core;

namespace Zeiss.Test
{
    internal class RunZeissTest
    {
        private static PeriodicAction periodicAction;

        private readonly IDataConnector _dataConnector;
        private readonly IDataStorage _storage;

        public RunZeissTest(
            IDataConnector dataConnector,
            IDataStorage storage)
        {
            _dataConnector = dataConnector;
            _storage = storage;
            periodicAction = new PeriodicAction(1);
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            await periodicAction.Run(async () =>
            {
                var data = await _dataConnector.ReceiveAsync(cancellationToken);
                if (data != null)
                {
                    await _storage.StoreAsync(new[] { data }, cancellationToken);
                }
            }, cancellationToken);
        }
    }
}
