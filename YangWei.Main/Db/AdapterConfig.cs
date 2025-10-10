using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangWei.Main.Db
{
    public class AdapterConfig 
    {
        public static AdapterConfig Instance { get; set; }=new AdapterConfig();

        public AdapterConfig()
        {
            
        }
    }
}
