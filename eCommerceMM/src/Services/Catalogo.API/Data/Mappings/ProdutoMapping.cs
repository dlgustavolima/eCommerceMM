﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Catalogo.API.Models;

namespace Catalogo.API.Data.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.Property(c => c.Descricao)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder.Property(c => c.Imagem)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder.ToTable("Produtos");
    }
}