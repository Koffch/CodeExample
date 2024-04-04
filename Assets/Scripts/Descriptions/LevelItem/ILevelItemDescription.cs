using UnityEngine;

namespace Descriptions.LevelItem
{
    public interface ILevelItemDescription : ITypedDescription
    {
        public string PrefabPath { get; }
        public Vector2 Position { get; }
        public float RotationZ { get; }
    }
}