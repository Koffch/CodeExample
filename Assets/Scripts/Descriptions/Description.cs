using System.Collections.Generic;

namespace Descriptions
{
    public abstract class Description : IDescription
    {
        public string Id { get; }

        protected Description(string id, IDictionary<string, object> node)
        {
            Id = id;
        }
    }
}