﻿using Identidade.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Core.Model;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;

namespace Identidade.API.Data;

public class ApplicationDbContext : IdentityDbContext, ISecurityKeyContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<KeyMaterial> SecurityKeys { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
}