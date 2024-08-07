﻿using aspLearning.Context;
using aspLearning.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Services;

public class UnitOfWork(MyContext context) : IUnitOfWork
{
    public IGenericRepository<T> Rep<T>() where T : class
    {
        return new GenericRepository<T>(context);
    }

    public int Complete()
    {
        return context.SaveChanges();
    }

    public DbContext Context => context;
}