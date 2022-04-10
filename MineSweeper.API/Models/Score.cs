using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeper.API.Models
{
    
    [Table("scores")]
    public class Score
    {

        public int Id { get; set; }
        
        [Required]
        [Range(0, 1000)]
        public int Points { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "You must supply a name between {2} - {1} characters", MinimumLength = 1)]
        public string PlayerName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }

    }
}
