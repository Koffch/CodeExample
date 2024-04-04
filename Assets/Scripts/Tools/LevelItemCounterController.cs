using System;
using TMPro;
using UnityEngine;

namespace Tools
{
    public class LevelItemCounterController : MonoBehaviour
    {
        [SerializeField] private TextMeshPro CounterLabel;

        private int _counterValue;

        public int Value
        {
            get => _counterValue;
            set
            {
                _counterValue = value;
                CounterLabel.text = _counterValue.ToString();
            }
        }

        public void Update()
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}