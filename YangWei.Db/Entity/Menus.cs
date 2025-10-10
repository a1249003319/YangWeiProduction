using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangWei.Db.Uitls;

namespace YangWei.Db.Entity
{
    [Table("Menus")]
    public class Menus:Entity1
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [MaxLength(length: 50)]
        public string  TitleName { get; set; }
        /// <summary>
        /// 父Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 菜单层级
        /// </summary>
        public int? Level { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[]? Icon { get; set; }


        [MaxLength(length:200)]
        public string? Permission { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
      
        public IsShows? IsShow { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(length:500)]
        public string? ReMark { get; set; }


        public IsShows? Status { get; set; }



    }

    /// <summary>
    /// 是否显示
    /// </summary>
    public enum IsShows
    {
        [Description("显示")]
        Show=1,
        [Description("不显示")]
        Hide=0
    }


    public enum IsStatus
    {
        [Description("禁用")]
        Hide=0,
        [Description("启用")]
        Show=1
    }
        
}
