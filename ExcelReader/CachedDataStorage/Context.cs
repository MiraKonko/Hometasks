using System;
using System.Collections.Generic;

namespace ExcelReader.CachedDataStorage
{
    public class Context
    {
        private readonly Dictionary<string, object> _dictionary;
        private static Context _context;

        public Context()
        {
            _dictionary = new Dictionary<string, object>();
        }

        public static Context Current
        {
            get
            {
                _context = _context ?? new Context();
                return _context;
            }
        }

        public void Set(string key, object value)
        {
            _dictionary[key] = value;
        }

        public bool Remove(string key)
        {
            return _dictionary.Remove(key);
        }

        public TObject Get<TObject>(string key) where TObject : class
        {
            if (!_dictionary.ContainsKey(key))
            {
                throw new Exception($"Such key: {key} was not found in Context");
            }
            return _dictionary[key] as TObject;
        }

        public bool TryGet<TObject>(string key, out TObject tObject) where TObject : class
        {
            if (!_dictionary.ContainsKey(key))
            {
                tObject = null;
                return false;
            }
            else
            {
                tObject = _dictionary[key] as TObject;
                return true;
            }
        }
    }
}
