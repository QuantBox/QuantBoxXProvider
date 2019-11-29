using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartQuant;

namespace QuantBox
{
    public static class StatisticsManagerExtensions
    {
        public static void Change(this StatisticsManager manager, int type, PortfolioStatisticsItem statisticsItem)
        {
            var i = (ICustomStatisticsType)statisticsItem;
            i.SetStatisticsType(type);
            manager.Add(statisticsItem);
        }

        public static void AddStatisticsItem(this StatisticsManager manager, PortfolioStatisticsItem statisticsItem)
        {
            var i = (ICustomStatisticsType)statisticsItem;
            if (i != null) {
                var max = 0;
                foreach (var item in manager.Statistics) {
                    if (item.GetType() == statisticsItem.GetType()) {
                        return;
                    }
                    max = Math.Max(max, item.Type);
                }
                i.SetStatisticsType(max + 1);
            }
            manager.Add(statisticsItem);
        }

        public static void RemoveStatisticsItem(this StatisticsManager manager, Type type)
        {
            var typeId = 0;
            foreach (var item in manager.Statistics) {
                if (item.GetType() == type) {
                    typeId = item.Type;
                }
            }
            if (typeId > 0) {
                manager.Remove(typeId);
            }
        }
    }
}
