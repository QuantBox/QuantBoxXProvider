using SmartQuant;

namespace QuantBox
{
    internal class QBOptimizeBarFilter : EventFilter
    {
        private readonly long[] _barSizes;
        private readonly long _size;

        public QBOptimizeBarFilter(Framework framework)
            : base(framework)
        {
            _barSizes = DataManagerExtensions.GlobalOptimizeBarFilter;
            if (_barSizes != null && _barSizes.Length == 1) {
                _size = _barSizes[0];
            }
        }

        public override Event Filter(Event e)
        {
            if (e.TypeId == DataObjectType.Bar) {
                var bar = (Bar)e;
                if (bar.Size == _size) {
                    return e;
                }
                foreach (var item in _barSizes) {
                    if (bar.Size == item) {
                        return e;
                    }
                }
                return null;
            }
            return e;
        }
    }
}