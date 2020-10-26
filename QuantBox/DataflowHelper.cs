using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace QuantBox
{
    internal static class DataflowHelper
    {
        public static readonly ExecutionDataflowBlockOptions SpscBlockOptions;

        static DataflowHelper() =>
            SpscBlockOptions = new ExecutionDataflowBlockOptions {
                SingleProducerConstrained = true,
                CancellationToken = CancellationToken.None,
                MaxDegreeOfParallelism = 1
            };
    }
}