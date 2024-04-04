using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Descriptions.LevelItem
{
    public class LevelItemDescription : TypedDescription, ILevelItemDescription
    {
        public string PrefabPath { get; }
        public Vector2 Position { get; }
        public float RotationZ { get; }

        public LevelItemDescription(string id, IDictionary<string, object> node) : base(id, node)
        {
            PrefabPath = node.GetString("prefab_path");
            Position = node.GetVector2("position");
            RotationZ = node.GetFloat("rotation_z");
        }
    }
}