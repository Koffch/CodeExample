using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Descriptions.LevelItem
{
    public class PatrolLevelItemDescription : LevelItemDescription
    {
        public float DetectRadius { get; private set; }
        public float MoveSpeed { get; private set; }
        public float RotationSpeed { get; private set; }
        public List<Vector2> PatrolWay { get; private set; }

        public PatrolLevelItemDescription(string id, IDictionary<string, object> node) : base(id, node)
        {
            DetectRadius = node.GetFloat("detect_radius");
            MoveSpeed = node.GetFloat("move_speed");
            RotationSpeed = node.GetFloat("rotation_speed");
            PatrolWay = node.GetVector2List("patrol_way");
        }
    }
}