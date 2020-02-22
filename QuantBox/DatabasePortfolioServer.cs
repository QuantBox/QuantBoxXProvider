using System;
using System.Linq;
using LiteDB;
using SmartQuant;

namespace QuantBox
{
    internal class DatabasePortfolioServer : PortfolioServer
    {
        private readonly LiteDatabase _database;
        private readonly ILiteCollection<Portfolio> _portfolios;

        public DatabasePortfolioServer(Framework framework, LiteDatabase database) : base(framework)
        {
            _database = database;
            _portfolios = _database.GetCollection<Portfolio>("portfolios");
        }

        public override Portfolio Load(string name)
        {
            var map = _portfolios.FindAll().ToDictionary(n => n.Id);
            var items = map.Values.ToList();
            items.Sort((x, y) => x.Id.CompareTo(y.Id));
            Portfolio root = null;
            foreach (var item in items) {
                item.Init(framework);
                framework.PortfolioManager.Add(item);
                if (item.ParentId == -1) {
                    root = item;
                }
                else {
                    var parent = map[item.ParentId];
                    parent.Children.Add(item);
                    item.Parent = parent;
                }
            }
            return root;
        }

        public override void Save(Portfolio portfolio)
        {
            _portfolios.Upsert(portfolio);
            foreach (var item in portfolio.Children) {
                Save(item);
            }
        }

        public override void Close()
        {
        }
    }
}