﻿namespace Pagamentos.MMPag;

public enum TransactionStatus
{
    Authorized = 1,
    Paid,
    Refused,
    Chargedback,
    Cancelled
}
