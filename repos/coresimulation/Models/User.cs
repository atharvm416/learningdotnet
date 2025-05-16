using System;
using System.Collections.Generic;

namespace coresimulation.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
