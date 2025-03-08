using System.Collections.Generic;
using System.Linq;
using MyDevTime.Interfaces.DataExtendable;

namespace MyDevTime.Abstracts.DataExtendable
{
    /// <summary>
    /// This class represents a node or possibly a leaf in a DataExtendable extension tree.
    /// </summary>
    /// <typeparam name="T">The type of the extension. Needs to implement <see cref="IDataExtension"/></typeparam>
    public abstract class ADataExtensionExtendable<T> : ADataExtension, IDataExtendable<T>
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
        /// <returns>True if the extension was able added otherwise false. The default implementation does not allow for duplicate <see cref="ExtensionId"/>s.</returns>
        public virtual bool AddDataExtension(T dataExtension)
        {
            if (Extensions is ISet<T> set)
            {
                return set.Add(dataExtension);
            }

            if (Extensions.Any(ex => ex.ExtensionId == dataExtension.ExtensionId))
            {
                Extensions.Add(dataExtension);

                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Removes an existing data extension from the object.
        /// </summary>
        /// <param name="dataExtension">The data extension to remove.</param>
        /// <returns>True if it <see cref="dataExtension"/> got removed otherwise false.</returns>
        public virtual bool RemoveDataExtension(T dataExtension)
        {
            if (Extensions is ISet<T> set)
            {
                return set.Remove(dataExtension);
            }


            var count = Extensions.Count;

            Extensions.Remove(dataExtension);

            if (count > Extensions.Count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a data extension by its unique identifier.
        /// </summary>
        /// <param name="extensionId">The id of the extension.</param>
        /// <param name="dataExtension">The requested extension or null</param>
        /// <returns>True if an extension was found otherwise false.</returns>
        public virtual bool GetDataExtension(string extensionId, out T dataExtension)
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
}