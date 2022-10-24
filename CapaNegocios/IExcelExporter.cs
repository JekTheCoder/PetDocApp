using System.Collections.Generic;

namespace CapaNegocios
{
    public interface IExcelExporter<T>
        where T : class
    {
        void Export(IEnumerable<T> list, string path);
    }
}
