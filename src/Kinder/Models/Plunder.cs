using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinder.Models
{
    [Table("Plunders")]
    public class Plunder
    {
        [Key]
        public int PlunderId { get; set; }
        public string PlunderName { get; set; }
        public string Type { get; set; }

        public int PlunderAttack { get; set; }
        public int PlunderDefense { get; set; }
        public int PlunderHP { get; set; }
    }
}
