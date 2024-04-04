using Descriptions.LevelItem;
using UnityEngine;

namespace Level.Items
{
    public abstract class LevelItemController<T> : MonoBehaviour, ILevelItemController where T : ILevelItemDescription
    {
        protected T Description { get; private set; }

        public virtual void Init(ILevelItemDescription description)
        {
            Description = (T) description;
            transform.localPosition = description.Position;
            var eulerAngles = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, description.RotationZ);
        }
    }
}