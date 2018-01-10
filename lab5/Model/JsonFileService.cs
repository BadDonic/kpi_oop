using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace lab5.ViewModel
{
    public class JsonFileService : IFileService
    {
        public List<Unit> Open(string filename)
        {
            List<Unit> phones = new List<Unit>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Unit>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = jsonFormatter.ReadObject(fs) as List<Unit>;
            }

            return phones;
        }

        public void Save(string filename, List<Unit> phonesList)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Unit>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, phonesList);
            }
        }
    }
}
