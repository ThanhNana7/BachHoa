namespace BH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MSKH { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(10)]
        public string TaiKhoang { get; set; }

        [StringLength(10)]
        public string MatKhau { get; set; }
    }
}
