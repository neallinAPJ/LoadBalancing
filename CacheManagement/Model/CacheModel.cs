using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagement.Model
{
    public class CacheModel
    {
        public string Key { get; set; }
        public List<string> KeyList
        {
            get
            {
                if(!string.IsNullOrEmpty(Key))
                {
                    return Key.Split(';').ToList();
                }
                return new List<string>();
            }
        }
    }
}
