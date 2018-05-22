namespace BH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPhieuTT")]
    public partial class CTPhieuTT
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOPTT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MSMH { get; set; }

        public int? SoLuongBan { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        public virtual MatHang MatHang { get; set; }

        public virtual PhieuThanhToan PhieuThanhToan { get; set; }
    }
}
