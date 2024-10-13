using System;
using System.Collections.Generic;

namespace DemoWebQLQCF.Models;

public partial class TTaiKhoan
{
    public int MaTaiKhoan { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string LoaiTaiKhoan { get; set; } = null!;

    public virtual ICollection<THoaDon> THoaDons { get; set; } = new List<THoaDon>();
}
