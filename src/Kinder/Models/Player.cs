using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinder.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAttack { get; set; }
        public int PlayerHP { get; set;}
        public int PlayerDefense { get; set; }
        public int Shield { get; set; }
        public int Weapon { get; set; }
        public int Armour { get; set; }
        public int Potion { get; set; }
        public virtual Plunder Plunder { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
