using System.Diagnostics.CodeAnalysis;
using MyDevTime.Interfaces.DataExtendable;

namespace MyDevTime.Abstracts.DataExtendable;

public abstract class ADataExtendable<T> : IDataExtendable<T>
    where T : class, IDataExtension
{
    #region Fields and Properties

    public ICollection<T> Extensions { get; set; }

    #endregion


    #region DataExtendableFunctions

    /// <summary>
    /// Adds a new data extension to the object.
    /// </summary>
    /// <param name="dataExtension">The data extension to add.</param>
    public bool AddDataExtension(T dataExtension)
    {
        if (Extensions is ISet<T> set) return set.Add(dataExtension);

        Extensions.Add(dataExtension);

        return true;
    }

    /// <summary>
    /// Removes an existing data extension from the object.
    /// </summary>
    /// <param name="dataExtension">The data extension to remove.</param>
    public bool RemoveDataExtension(T dataExtension)
    {
        if (Extensions is ISet<T> set) return set.Remove(dataExtension);


        var count = Extensions.Count;

        Extensions.Remove(dataExtension);

        if (count > Extensions.Count) return true;

        return false;
    }

    /// <summary>
    /// Retrieves a data extension by its unique identifier.
    /// </summary>
    /// <param name="extensionId">The id of the extension.</param>
    /// <param name="dataExtension">The requested extension or null</param>
    /// <returns>True if an extension was found otherwise false.</returns>
    public bool GetDataExtension(string extensionId, [NotNullWhen(true)] out T? dataExtension)
    {
        dataExtension = null;

        if (Extensions.Any(ex => ex.ExtensionId == extensionId))
        {
            dataExtension = Extensions.First(ex => ex.ExtensionId == extensionId);

            return true;
        }

        return false;
    }

    #endregion
}