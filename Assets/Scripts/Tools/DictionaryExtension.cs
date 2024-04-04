using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public static class DictionaryExtension
    {
        public static IDictionary<string, object> GetNode(this IDictionary<string, object> node, string key)
        {
            return (IDictionary<string, object>) node[key];
        }

        public static string GetString(this IDictionary<string, object> node, string key, string defaultValue = "")
        {
            return node.TryGetValue(key, out var value) ? value.ToString() : defaultValue;
        }

        public static bool GetBool(this IDictionary<string, object> node, string key, bool defaultValue = false)
        {
            return node.TryGetValue(key, out var value) ? Convert.ToBoolean(value) : defaultValue;
        }

        public static int GetInt(this IDictionary<string, object> node, string key, int defaultValue = 0)
        {
            return node.TryGetValue(key, out var value) ? Convert.ToInt32(value) : defaultValue;
        }

        public static float GetFloat(this IDictionary<string, object> node, string key, float defaultValue = 0)
        {
            return node.TryGetValue(key, out var value) ? Convert.ToSingle(value) : defaultValue;
        }

        public static List<float> GetFloatList(this IDictionary<string, object> node, string key)
        {
            var list = new List<float>();
            if (node.TryGetValue(key, out var value))
                foreach (var o in (List<object>) value)
                    list.Add(Convert.ToSingle(o));
            return list;
        }

        public static Vector2 GetVector2(this IDictionary<string, object> node, string key, Vector2 defaultValue = new())
        {
            var list = node.GetFloatList(key);
            return list.Count == 2 ? new Vector2(list[0], list[1]) : defaultValue;
        }

        public static List<Vector2> GetVector2List(this IDictionary<string, object> node, string key)
        {
            var list = new List<Vector2>();
            var listF = new List<float>();
            if (node.TryGetValue(key, out var value))
                foreach (var o in (List<object>) value)
                {
                    foreach (var v in (List<object>) o)
                        listF.Add(Convert.ToSingle(v));
                    if (listF.Count == 2)
                        list.Add(new Vector2(listF[0], listF[1]));
                    listF.Clear();
                }
            return list;
        }
    }
}