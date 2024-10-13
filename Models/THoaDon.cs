using System;
using System.Collections.Generic;

namespace DemoWebQLQCF.Models;

public partial class THoaDon
{
    public int MaHoaDon { get; set; }

    public int? MaBan { get; set; }

    public DateTime NgayLap { get; set; }

    public decimal TongTien { get; set; }

    public int? MaTaiKhoan { get; set; }

    public virtual TBan? MaBanNavigation { get; set; }

    public virtual TTaiKhoan? MaTaiKhoanNavigation { get; set; }

    public virtual ICollection<TChiTietHd> TChiTietHds { get; set; } = new List<TChiTietHd>();
}
