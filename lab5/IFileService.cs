using System.Collections.Generic;

namespace lab5
{
    public interface IFileService
    {
        List<Unit> Open(string filename);
        void Save(string filename, List<Unit> phonesList);
    }
}
