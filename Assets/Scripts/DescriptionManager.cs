using System.Collections.Generic;
using Descriptions;
using Descriptions.LevelItem;
using fastJSON;
using Tools;
using UnityEngine;

public class DescriptionManager
{
    public Dictionary<string, ILevelItemDescription> ItemsData { get; private set; }

    private Dictionary<string, Dictionary<string, object>> _filesData;
    private Factory _factory;

    public void Load()
    {
        _filesData = new Dictionary<string, Dictionary<string, object>>();
        var textAssets = Resources.LoadAll<TextAsset>("Jsons");
        foreach (var textAsset in textAssets)
        {
            var node = (Dictionary<string, object>) JSON.Parse(textAsset.text);
            _filesData.Add(textAsset.name, node);
        }

        _factory = new Factory();

        ItemsData = BuildTyped<ILevelItemDescription>(GetNodeWithClear("level_items"));
    }

    private Dictionary<string, T> BuildTyped<T>(IDictionary<string, object> node) where T : ITypedDescription
    {
        var result = new Dictionary<string, T>();
        foreach (var key in node.Keys)
        {
            var rawData = node.GetNode(key);
            result.Add(key, _factory.Build<T>(rawData.GetString("type"), key, rawData));
        }

        return result;
    }

    private IDictionary<string, object> GetNodeWithClear(string key)
    {
        var dictionary = _filesData[key];
        _filesData.Remove(key);
        return dictionary;
    }
}