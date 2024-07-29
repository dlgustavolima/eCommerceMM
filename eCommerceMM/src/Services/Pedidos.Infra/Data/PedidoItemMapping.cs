﻿using Pedidos.Domain.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pedidos.Infra.Data;

public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.ProdutoNome)
            .IsRequired()
            .HasColumnType("varchar(250)");

        // 1 : N => Pedido : Pagamento
        builder.HasOne(c => c.Pedido)
            .WithMany(c => c.PedidoItems);

        builder.ToTable("PedidoItems");
    }
}
