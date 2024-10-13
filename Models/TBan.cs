using System;
using System.Collections.Generic;

namespace DemoWebQLQCF.Models;

public partial class TBan
{
    public int MaBan { get; set; }

    public string TenBan { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<THoaDon> THoaDons { get; set; } = new List<THoaDon>();
}
