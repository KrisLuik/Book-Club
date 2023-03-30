using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApi.Models
{
    [Table("Rating")]
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rating_id { get; set; }
        public int book_id { get; set; }
        public int person_id { get; set; }
        public decimal rating { get;set; }
    }
}
