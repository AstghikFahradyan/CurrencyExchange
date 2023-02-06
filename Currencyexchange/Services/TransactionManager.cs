using Currencyexchange.DataSource;
using Currencyexchange.Models;
using Currencyexchange.Services.Interface;

namespace Currencyexchange.Services
{
    public class TransactionManager : IDataRepository<Transaction>
    {
        readonly TransactionContext _transactionContext;
        public TransactionManager(TransactionContext context)
        {
            _transactionContext = context;
        }
        public IEnumerable<Transaction> GetAll()
        {
            return _transactionContext.Transactions;
        }
        public Transaction Get(long id)
        {
            return _transactionContext.Transactions.FirstOrDefault(e => e.Id == id);
        }
        public void Add(Transaction entity)
        {
            _transactionContext.Transactions.Add(entity);
            _transactionContext.SaveChanges();
        }
        public void Update(Transaction transaction, Transaction entity)
        {
            transaction.DateOfTransaction = DateTime.Now;
            transaction.ExchangeType = entity.ExchangeType;
            transaction.ExchangeKey = entity.ExchangeKey;
            transaction.ExchangeValue = entity.ExchangeValue;
            transaction.AmountFor = entity.AmountFor;
            transaction.AmountTo = entity.AmountTo;
            transaction.Status = entity.Status;
            _transactionContext.SaveChanges();
        }
        public void Delete(Transaction transaction)
        {
            _transactionContext.Transactions.Remove(transaction);
            _transactionContext.SaveChanges();
        }
    }
}
