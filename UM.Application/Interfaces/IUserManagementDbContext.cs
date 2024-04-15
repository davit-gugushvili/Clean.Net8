﻿using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Entities;

namespace UM.Application.Interfaces
{
    public interface IUserManagementDbContext
    {
        DbSet<Token> Tokens { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
    }
}
