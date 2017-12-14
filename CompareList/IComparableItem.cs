namespace ListComparer
{
    public interface IComparableItem<T>
    {
        string GetKeysToFindDeletedItems();
        string GetKeysToFindAddedItems();
        string GetKeysToFindUpdatedItems();
    }


}
