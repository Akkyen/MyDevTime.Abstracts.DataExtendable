using MyDevTime.Interfaces.DataExtendable;

namespace MyDevTime.Abstracts.DataExtendable;

public abstract class ADataExtension : IDataExtension
{
    public string ExtensionId { get; set; }
}