using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DB;

public partial class Staff
{
    [Display(Name = "Id")]
    public int StaffId { get; set; }
    [Display(Name ="Nome")]
    public string FirstName { get; set; } = null!;
    [Display(Name = "Cognome")]
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public byte Active { get; set; }

    public int StoreId { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Staff> InverseManager { get; set; } = new List<Staff>();

    public virtual Staff? Manager { get; set; }
}
