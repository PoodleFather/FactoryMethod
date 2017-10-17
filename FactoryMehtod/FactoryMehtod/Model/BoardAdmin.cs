using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryMehtodLib.Model
{
    [Table("BoardAdmin")]
    public partial class BoardAdmin
    {
        [Key]
        public int BoardAdmin_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Cate { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminId { get; set; }

        [StringLength(50)]
        public string BoardName { get; set; }

        public string BoardTitle { get; set; }

        public int JoinerId { get; set; }
    }
}
