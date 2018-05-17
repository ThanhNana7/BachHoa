namespace BachHoa1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [StringLength(20)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string Quyen { get; set; }
    }
}
