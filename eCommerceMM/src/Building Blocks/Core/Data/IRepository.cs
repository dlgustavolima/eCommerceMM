﻿using Core.DomainObjects;

namespace Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; }
}