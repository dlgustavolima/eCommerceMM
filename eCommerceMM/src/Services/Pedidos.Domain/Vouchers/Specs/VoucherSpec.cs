﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NetDevPack.Specification;

namespace Pedidos.Domain.Vouchers.Specs;

public class VoucherDataSpecification : Specification<Voucher>
{
    public override Expression<Func<Voucher, bool>> ToExpression()
    {
        return voucher => voucher.DataValidade >= DateTime.Now;
    }
}

public class VoucherQuantidadeSpecification : Specification<Voucher>
{
    public override Expression<Func<Voucher, bool>> ToExpression()
    {
        return voucher => voucher.Quantidade > 0;
    }
}

public class VoucherAtivoSpecification : Specification<Voucher>
{
    public override Expression<Func<Voucher, bool>> ToExpression()
    {
        return voucher => voucher.Ativo && !voucher.Utilizado;
    }
}
