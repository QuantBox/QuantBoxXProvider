
namespace QuantBox
{
    using SmartQuant;

    internal class StopStrategy : Strategy
    {
        public StopStrategy(Framework framework, Strategy strategy, string name)
            : base(framework, name)
        {
            RealStrategy = strategy;
        }

        public Strategy RealStrategy { get; }

        protected override void OnStopStatusChanged_(Stop stop)
        {
            stop.SetStrategy(RealStrategy);
            RealStrategy.CallStopStatusChanged(stop);
            StrategyServer.RemoveStop(stop);
        }
    }
}