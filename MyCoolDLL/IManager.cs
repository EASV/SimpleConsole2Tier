using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolDLL
{
    public interface IManager <T>
    {
        /// <summary>
        /// Generic Create method. 
        /// Will return the created item with a ID
        /// </summary>
        /// <param name="t">Any object</param>
        /// <returns></returns>
        T Create(T t);

        /// <summary>
        /// Chokolate
        /// </summary>
        /// <returns></returns>
        List<T> ReadAll();

        /// <summary>
        /// I think I found a cool thing for delegates
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Read(int id);

        /// <summary>
        /// Updates T
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Update(T t);

        /// <summary>
        /// Coffee rocks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
