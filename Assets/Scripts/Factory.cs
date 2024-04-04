using System;
using System.Collections.Generic;
using Descriptions.LevelItem;

public class Factory
{
    private readonly Dictionary<Type, Dictionary<string, Type>> _variants = new();

    public Factory()
    {
        AddVariant<ILevelItemDescription>("", typeof(LevelItemDescription));
        AddVariant<ILevelItemDescription>("patrol", typeof(PatrolLevelItemDescription));
        AddVariant<ILevelItemDescription>("thief", typeof(ThiefLevelItemDescription));
    }

    private void AddVariant<T>(string key, Type type)
    {
        var baseType = typeof(T);
        if (!_variants.ContainsKey(baseType))
        {
            _variants[baseType] = new Dictionary<string, Type>();
        }

        _variants[baseType][key] = type;
    }

    public T Build<T>(string key, params object[] param)
    {
        var type = typeof(T);
        var data = _variants[type];
        return (T) Activator.CreateInstance(data[key], param);
    }
}