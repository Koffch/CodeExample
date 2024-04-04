using Descriptions.LevelItem;

namespace Level.Items
{
    public interface ILevelItemController
    {
        void Init(ILevelItemDescription description);
    }
}