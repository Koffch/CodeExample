namespace Descriptions
{
    public interface ITypedDescription : IDescription
    {
        public string Type { get; }
    }
}