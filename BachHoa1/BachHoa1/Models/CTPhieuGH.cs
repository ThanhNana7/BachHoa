namespace BachHoa1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPhieuGH")]
    public partial class CTPhieuGH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOPG { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MSMH { get; set; }

        public int? SoLuongGiao { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        public virtual MatHang MatHang { get; set; }

        public virtual PhieuGiaoHang PhieuGiaoHang { get; set; }
    }
}
