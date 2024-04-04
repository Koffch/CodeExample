using Descriptions.LevelItem;
using UnityEngine;

namespace Level.Items
{
    public class TreasureLevelItemController : LevelItemController<LevelItemDescription>
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Thief"))
                transform.localPosition = GetRandomPoint();
        }

        private static Vector3 GetRandomPoint()
        {
            return new Vector3(Random.Range(-10, 10), Random.Range(-10, 10));
        }
    }
}