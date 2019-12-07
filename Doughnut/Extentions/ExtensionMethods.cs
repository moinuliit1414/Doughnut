using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Doughnut.Extentions
{
    public static class ExtensionMethods
    {
        /// <summary>
        ///     Return new deep cloned Object ref.
        /// </summary>
        /// <param name="toClone">
        ///     Original object which to be clone. 
        /// </param>
        /// <returns>
        ///     Returns copy of given Object. 
        /// </returns>
        public static T DeepClone<T>(this T toClone)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, toClone);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
