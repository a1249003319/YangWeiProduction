using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangWei.Db.Uitls;

namespace YangWei.Db.Entity
{
    [Table("Users")]
    public class Users:Entity1
    {
        public string NikeName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IsState? State { get; set; }
    }


    public enum IsState
    {
        [Description("在线")]
        OnState=1,
        [Description("离线")]
        UnState=0
    }
}
