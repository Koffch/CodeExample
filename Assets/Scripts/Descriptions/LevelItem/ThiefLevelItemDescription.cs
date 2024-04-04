using System.Collections.Generic;
using Tools;

namespace Descriptions.LevelItem
{
    public class ThiefLevelItemDescription : LevelItemDescription
    {
        public float DetectRadius { get; private set; }
        public float MoveSpeed { get; private set; }
        public float RotationSpeed { get; private set; }

        public ThiefLevelItemDescription(string id, IDictionary<string, object> node) : base(id, node)
        {
            DetectRadius = node.GetFloat("detect_radius");
            MoveSpeed = node.GetFloat("move_speed");
            RotationSpeed = node.GetFloat("rotation_speed");
        }
    }
}