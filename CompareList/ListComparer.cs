using System.Collections.Generic;
using System.Linq;

namespace ListComparer
{
    public class ListComparer<T>
         where T : IComparableItem<T>
    {
        IList<T> _source;
        IList<T> _destination;

        public ListComparer(IList<T> source, IList<T> destination)
        {
            _source = source;
            _destination = destination;
        }

        public IEnumerable<T> GetAddedItems()
        {
            return _source.GroupJoin(_destination, x => x.GetKeysToFindAddedItems(), y => y.GetKeysToFindAddedItems(), (x, y) => new { S = x, D = y })
                .SelectMany(m => m.D.DefaultIfEmpty(), (m, n) => new { S = m, D = n }).Where(m => m.D == null).Select(n => n.S.S);
        }

        public IEnumerable<T> GetDeletedItems(IEnumerable<T> source, IEnumerable<T> destination)
        {
            return destination.GroupJoin(source, x => x.GetKeysToFindDeletedItems(), y => y.GetKeysToFindDeletedItems(), (x, y) => new { S = x, D = y })
               .SelectMany(m => m.D.DefaultIfEmpty(), (m, n) => new { S = m, D = n }).Where(m => m.D == null).Select(n => n.S.S);
        }

        public IEnumerable<T> GetUpdatedItems()
        {
            var insertedItems = GetAddedItems().Select(n => n.GetKeysToFindAddedItems()).ToList();



            //Take out the inserted items from source
            var source = _source.Where(m => !insertedItems.Contains(m.GetKeysToFindAddedItems()));



            return source
                .GroupJoin(_destination, x => x.GetKeysToFindUpdatedItems(), y => y.GetKeysToFindUpdatedItems(), (x, y) => new { S = x, D = y })
               .SelectMany(m => m.D.DefaultIfEmpty(), (m, n) => new { S = m, D = n }).Where(m => m.D == null).Select(n => n.S.S);
        }
    }


}
