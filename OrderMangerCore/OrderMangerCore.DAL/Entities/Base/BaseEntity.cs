﻿namespace OrderMangerCore.DAL.Entities.Base;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
}