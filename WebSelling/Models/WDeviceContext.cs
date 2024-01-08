using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebSelling.Models
{
    public partial class WDeviceContext : DbContext
    {
        public WDeviceContext()
        {
        }

        public WDeviceContext(DbContextOptions<WDeviceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnhChiTietSp> AnhChiTietSps { get; set; } = null!;
        public virtual DbSet<AnhSanPham> AnhSanPhams { get; set; } = null!;
        public virtual DbSet<ChatLieu> ChatLieus { get; set; } = null!;
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; } = null!;
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; } = null!;
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<GioHang> GioHangs { get; set; } = null!;
        public virtual DbSet<HangSanXuat> HangSanXuats { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<KichThuoc> KichThuocs { get; set; } = null!;
        public virtual DbSet<LoaiDt> LoaiDts { get; set; } = null!;
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; } = null!;
        public virtual DbSet<MauSac> MauSacs { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<QuocGium> QuocGia { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-17SOHDC3\\MSSQLSERVER01;Initial Catalog=W-Device;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnhChiTietSp>(entity =>
            {
                entity.HasKey(e => new { e.MaChiTietSp, e.TenFileAnh });

                entity.ToTable("AnhChiTietSP");

                entity.Property(e => e.MaChiTietSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaChiTietSP")
                    .IsFixedLength();

                entity.Property(e => e.TenFileAnh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.MaChiTietSpNavigation)
                    .WithMany(p => p.AnhChiTietSps)
                    .HasForeignKey(d => d.MaChiTietSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AnhChiTie__MaChi__70DDC3D8");
            });

            modelBuilder.Entity<AnhSanPham>(entity =>
            {
                entity.HasKey(e => new { e.MaSanPham, e.TenFileAnh });

                entity.ToTable("AnhSanPham");

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenFileAnh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.AnhSanPhams)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AnhSanPha__MaSan__656C112C");
            });

            modelBuilder.Entity<ChatLieu>(entity =>
            {
                entity.HasKey(e => e.MaChatLieu)
                    .HasName("PK__ChatLieu__453995BCC5332822");

                entity.ToTable("ChatLieu");

                entity.Property(e => e.MaChatLieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChatLieu1)
                    .HasMaxLength(150)
                    .HasColumnName("ChatLieu");
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.MaDonHang, e.MaSanPham })
                    .HasName("PK__ChiTietD__DD39F0EF5F9348CB");

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.MaDonHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DonGia).HasColumnType("money");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDo__MaDon__05D8E0BE");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDo__MaSan__06CD04F7");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaChiTietSp });

                entity.ToTable("ChiTietHoaDon");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaChiTietSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaChiTietSP")
                    .IsFixedLength();

                entity.Property(e => e.DonGiaBan).HasColumnType("money");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.HasOne(d => d.MaChiTietSpNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaChiTietSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHo__MaChi__74AE54BC");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHo__MaHoa__73BA3083");
            });

            modelBuilder.Entity<ChiTietSanPham>(entity =>
            {
                entity.HasKey(e => e.MaChiTietSp)
                    .HasName("PK__ChiTietS__651D90575B804A2D");

                entity.ToTable("ChiTietSanPham");

                entity.Property(e => e.MaChiTietSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaChiTietSP")
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaKichThuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaMauSac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Video)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VIDEO")
                    .IsFixedLength();

                entity.HasOne(d => d.MaKichThuocNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaKichThuoc)
                    .HasConstraintName("FK__ChiTietSa__MaKic__6D0D32F4");

                entity.HasOne(d => d.MaMauSacNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaMauSac)
                    .HasConstraintName("FK__ChiTietSa__MaMau__6E01572D");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK__ChiTietSa__MaSan__6C190EBB");
            });

            modelBuilder.Entity<DanhMucSanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK__DanhMucS__FAC7442DEC45BBA2");

                entity.ToTable("DanhMucSanPham");

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AnhSanPham)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GiaLonNhat).HasColumnType("money");

                entity.Property(e => e.GiaNhoNhat).HasColumnType("money");

                entity.Property(e => e.MaChatLieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaDacTinh)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaDt)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaDT")
                    .IsFixedLength();

                entity.Property(e => e.MaHangSanXuat)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaNuocSanXuat)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.TenSanPham).HasMaxLength(100);

                entity.HasOne(d => d.MaChatLieuNavigation)
                    .WithMany(p => p.DanhMucSanPhams)
                    .HasForeignKey(d => d.MaChatLieu)
                    .HasConstraintName("FK__DanhMucSa__MaCha__5EBF139D");

                entity.HasOne(d => d.MaDtNavigation)
                    .WithMany(p => p.DanhMucSanPhams)
                    .HasForeignKey(d => d.MaDt)
                    .HasConstraintName("FK__DanhMucSan__MaDT__628FA481");

                entity.HasOne(d => d.MaHangSanXuatNavigation)
                    .WithMany(p => p.DanhMucSanPhams)
                    .HasForeignKey(d => d.MaHangSanXuat)
                    .HasConstraintName("FK__DanhMucSa__MaHan__5FB337D6");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.DanhMucSanPhams)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK__DanhMucSa__MaLoa__619B8048");

                entity.HasOne(d => d.MaNuocSanXuatNavigation)
                    .WithMany(p => p.DanhMucSanPhams)
                    .HasForeignKey(d => d.MaNuocSanXuat)
                    .HasConstraintName("FK__DanhMucSa__MaNuo__60A75C0F");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDonHang)
                    .HasName("PK__DonHang__129584AD300BF7B8");

                entity.ToTable("DonHang");

                entity.Property(e => e.MaDonHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(150);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgayDatHang).HasColumnType("date");

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK__DonHang__MaKhach__02FC7413");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.MaGioHang)
                    .HasName("PK__GioHang__F5001DA34C0918E3");

                entity.ToTable("GioHang");

                entity.Property(e => e.MaGioHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.GiaTien).HasColumnType("money");

                entity.Property(e => e.TenSanPham).HasMaxLength(100);
            });

            modelBuilder.Entity<HangSanXuat>(entity =>
            {
                entity.HasKey(e => e.MaHangSanXuat)
                    .HasName("PK__HangSanX__977119FC2F4D98CC");

                entity.ToTable("HangSanXuat");

                entity.Property(e => e.MaHangSanXuat)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HangSanXuat1)
                    .HasMaxLength(100)
                    .HasColumnName("HangSanXuat");

                entity.Property(e => e.MaNuocThuongHieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__HoaDon__835ED13B70D93B48");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSoThue)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgayHoaDon).HasColumnType("date");

                entity.Property(e => e.ThongTinThue).HasMaxLength(250);

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK__HoaDon__MaKhachH__5165187F");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK__HoaDon__MaNhanVi__52593CB8");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__KhachHan__88D2F0E52331B457");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(150);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenKhachHang).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__KhachHang__usern__4E88ABD4");
            });

            modelBuilder.Entity<KichThuoc>(entity =>
            {
                entity.HasKey(e => e.MaKichThuoc)
                    .HasName("PK__KichThuo__22BFD6641B3DEBA2");

                entity.ToTable("KichThuoc");

                entity.Property(e => e.MaKichThuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KichThuoc1)
                    .HasMaxLength(150)
                    .HasColumnName("KichThuoc")
                    .IsFixedLength();
            });

            modelBuilder.Entity<LoaiDt>(entity =>
            {
                entity.HasKey(e => e.MaDt)
                    .HasName("PK__LoaiDT__27258655B78CD971");

                entity.ToTable("LoaiDT");

                entity.Property(e => e.MaDt)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaDT")
                    .IsFixedLength();

                entity.Property(e => e.TenLoai).HasMaxLength(100);
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK__LoaiSanP__730A575974D8CF9D");

                entity.ToTable("LoaiSanPham");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Loai).HasMaxLength(100);
            });

            modelBuilder.Entity<MauSac>(entity =>
            {
                entity.HasKey(e => e.MaMauSac)
                    .HasName("PK__MauSac__B9A91162D83D4A0D");

                entity.ToTable("MauSac");

                entity.Property(e => e.MaMauSac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenMauSac).HasMaxLength(100);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__77B2CA4777883F29");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChucVu).HasMaxLength(100);

                entity.Property(e => e.DiaChi).HasMaxLength(150);

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNhanVien).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__NhanVien__userna__4BAC3F29");
            });

            modelBuilder.Entity<QuocGium>(entity =>
            {
                entity.HasKey(e => e.MaNuoc)
                    .HasName("PK__QuocGia__21306FEA8D6493DE");

                entity.Property(e => e.MaNuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNuoc).HasMaxLength(100);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__TaiKhoan__F3DBC573B5181B91");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.Property(e => e.LoaiUser).HasColumnName("Loai_user");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
