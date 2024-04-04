using System.Collections.Generic;
using Descriptions.LevelItem;
using Level.Items;
using UnityEngine;

namespace Level
{
    public class LevelContentController : MonoBehaviour
    {
        public Transform ItemsParent;

        public void Init(Dictionary<string, ILevelItemDescription> itemsData)
        {
            foreach (var itemDescription in itemsData.Values)
            {
                var original = (GameObject) Resources.Load(itemDescription.PrefabPath);
                var controller = Instantiate(original, ItemsParent).GetComponent<ILevelItemController>();
                controller.Init(itemDescription);
            }
        }
    }
}