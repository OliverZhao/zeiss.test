using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.Test.Contracts;

namespace Zeiss.Test.Core
{
    public class PeriodicAction
    {
        private PeriodicTimer _timer;

        public PeriodicAction(
            int periodicSeconds)
        {
        }

        public async Task Run(Action action, CancellationToken cancellationToken)
        {
            while (await _timer.WaitForNextTickAsync(cancellationToken))
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    // handle exception
                }
            }
        }
    }
}
