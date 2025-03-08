using MyDevTime.Interfaces.DataExtendable;

namespace MyDevTime.Abstracts.DataExtendable
{
    /// <summary>
    /// This class represents a leaf in a DataExtendable extension tree.
    /// </summary>
    public abstract class ADataExtension : IDataExtension
    {
        public string ExtensionId { get; set; }
    }
}