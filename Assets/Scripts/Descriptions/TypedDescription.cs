using System.Collections.Generic;
using Tools;

namespace Descriptions
{
    public abstract class TypedDescription : Descriptions.Description, ITypedDescription
    {
        public string Type { get; }

        protected TypedDescription(string id, IDictionary<string, object> node) : base(id, node)
        {
            Type = node.GetString("type");
        }
    }
}