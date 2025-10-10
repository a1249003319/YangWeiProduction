using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangWei.Db.IApply;

namespace YangWei.Db.Apply
{
    public class MemoryProfileService : IMemoryProfileService
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        readonly static Dictionary<string,object> values=new Dictionary<string, object>();
        public T Get<T>(string key)
        {
            values.TryGetValue(key, out object value);
            return (T)value;
        }

        public void Set<T>(string key, T value)
        {
            values[key] = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
        }
    }
}
