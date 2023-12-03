using com.gaurav.main.infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace com.gaurav.main.infrastructure.Repository
{
    class FinancialStatementRepository : IRepository<FinancialStatement>
    {
        private readonly BloggingContext _db;

        private bool disposed = false;

        public FinancialStatementRepository(BloggingContext db)
        {
            _db = db;
        }

        public void Add(FinancialStatement value)
        {
            _db.FinancialStatements?.Add(value);
        }

        public void Delete(int id)
        {
            var statement = _db.FinancialStatements?.Find(id);
            if (statement != null)
            {
                _db.FinancialStatements?.Remove(statement);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public FinancialStatement? Find(int id)
        {
            return _db.FinancialStatements?.Find(id);
        }

        public IEnumerable<FinancialStatement>? Get()
        {
            return _db.FinancialStatements?.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(FinancialStatement value)
        {
            _db.Entry(value).State = EntityState.Modified;
        }
    }
}