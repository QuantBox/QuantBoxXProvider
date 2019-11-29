using SmartQuant;

namespace QuantBox
{
    public class TradesCost : PortfolioStatisticsItem, ICustomStatisticsType
    {
        public static int TypeId;

        protected override void OnRoundTrip(TradeInfo trade)
        {
            var cost = trade.EntryCost + trade.ExitCost;
            if (trade.IsLong) {
                longValue += cost;
                longValues.Add(Clock.DateTime, longValue);
            }
            else {
                shortValue += cost;
                shortValues.Add(Clock.DateTime, shortValue);
            }
            totalValue += cost;
            totalValues.Add(Clock.DateTime, totalValue);
            Emit();
        }

        public override string Category
        {
            get
            {
                return "Trades";
            }
        }

        public override string Name
        {
            get
            {
                return "Trades Cost";
            }
        }

        public override int Type
        {
            get
            {
                return TypeId;
            }
        }

        public void SetStatisticsType(int type)
        {
            TypeId = type;
        }
    }
}
