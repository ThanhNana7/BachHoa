namespace BH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoCao")]
    public partial class BaoCao
    {
        public int? MSMH { get; set; }

        [Key]
        public int MSBC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThangNam { get; set; }

        public double? TongTien { get; set; }

        public virtual MatHang MatHang { get; set; }
    }
}
