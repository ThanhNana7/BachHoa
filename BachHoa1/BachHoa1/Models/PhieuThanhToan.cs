namespace BachHoa1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThanhToan")]
    public partial class PhieuThanhToan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuThanhToan()
        {
            CTPhieuTTs = new HashSet<CTPhieuTT>();
        }

        [Key]
        public int SOPTT { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLapPhieu { get; set; }

        public int MSCH { get; set; }

        public int MSVN { get; set; }

        public double TongCong { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuTT> CTPhieuTTs { get; set; }

        public virtual NVThanhToan NVThanhToan { get; set; }
    }
}
