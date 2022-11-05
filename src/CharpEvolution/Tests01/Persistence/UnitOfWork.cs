﻿using System;

namespace CsharpEvolution.Tests01.Persistence
{
    public interface IUnitOfWork
    {
        IDbContextCalculatorRepository DbContextRepository { get; }
        ICalculatorRepository CalculatorRepository { get; }

        void BeginTransaction();
        void Commit();
        void RollBack();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PerformedOperationContext _operationContext;
        private  IDbContextCalculatorRepository _dbCalculatorRepository = null;  
        private  ICalculatorRepository _calculatorRepository = null;
        private bool disposed = false;

        public UnitOfWork(PerformedOperationContext operationContext)
        {
            _operationContext = operationContext;
        }

        public IDbContextCalculatorRepository DbContextRepository
        {
            get
            {
                if (_dbCalculatorRepository == null)
                {
                    _dbCalculatorRepository = new DbContextCalculatorRepository(_operationContext);
                }
                return _dbCalculatorRepository;
            }
        }

        public ICalculatorRepository CalculatorRepository
        {
            get
            {
                if (_calculatorRepository == null)
                {
                    _calculatorRepository = new CalculatorRepository(_operationContext);
                }
                return _calculatorRepository;
            }
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _operationContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _operationContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
