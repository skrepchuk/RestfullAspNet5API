using System.ComponentModel.DataAnnotations.Schema;

namespace RESTfullAPI.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
