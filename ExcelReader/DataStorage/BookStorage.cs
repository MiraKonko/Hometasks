using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.CachedDataStorage
{
    public class BookStorage
    {
        private static Dictionary<string, List<BookDto>> _storedData;

        public static Dictionary<string, List<BookDto>> SavedBookStorages
        {
            get
            {
                _storedData = _storedData ?? new Dictionary<string, List<BookDto>>();
                return _storedData;
            }
        }

        public static List<BookDto> Instance
        {
            get
            {
                return SavedBookStorages.SelectMany(storage => storage.Value).ToList();
            }
        }
    }
}
