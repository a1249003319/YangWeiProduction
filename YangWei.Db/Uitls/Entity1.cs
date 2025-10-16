using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangWei.Db.Uitls
{
    public class Entity1
    {
        /// <summary>
        /// Id自增
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdateTime { get; set; }= DateTime.Now;
        [Required]
        public string CreateUser { get; set; } = "test";
        [Required]
        public string UpdateUser { get; set; } = "test";

        }
}
