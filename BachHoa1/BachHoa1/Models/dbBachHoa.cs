namespace BachHoa1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbBachHoa : DbContext
    {
        public dbBachHoa()
            : base("name=dbBachHoa")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BaoCao> BaoCaos { get; set; }
        public virtual DbSet<CTPhieuGH> CTPhieuGHs { get; set; }
        public virtual DbSet<CTPhieuTT> CTPhieuTTs { get; set; }
        public virtual DbSet<CuaHang> CuaHangs { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<MatHang> MatHangs { get; set; }
        public virtual DbSet<NVPhuTrach> NVPhuTraches { get; set; }
        public virtual DbSet<NVThanhToan> NVThanhToans { get; set; }
        public virtual DbSet<PhieuGiaoHang> PhieuGiaoHangs { get; set; }
        public virtual DbSet<PhieuThanhToan> PhieuThanhToans { get; set; }
        public virtual DbSet<TonKho> TonKhoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<CuaHang>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.CuaHangs)
                .WithRequired(e => e.LoaiHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.CTPhieuGHs)
                .WithRequired(e => e.MatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.CTPhieuTTs)
                .WithRequired(e => e.MatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.TonKhoes)
                .WithRequired(e => e.MatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NVPhuTrach>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NVPhuTrach>()
                .HasMany(e => e.CuaHangs)
                .WithOptional(e => e.NVPhuTrach1)
                .HasForeignKey(e => e.NvPhuTrach);

            modelBuilder.Entity<NVThanhToan>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NVThanhToan>()
                .HasMany(e => e.PhieuThanhToans)
                .WithRequired(e => e.NVThanhToan)
                .HasForeignKey(e => e.MSVN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuGiaoHang>()
                .HasMany(e => e.CTPhieuGHs)
                .WithRequired(e => e.PhieuGiaoHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuThanhToan>()
                .HasMany(e => e.CTPhieuTTs)
                .WithRequired(e => e.PhieuThanhToan)
                .WillCascadeOnDelete(false);
        }
    }
}
