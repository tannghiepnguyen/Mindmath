using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Repository.Persistence;

namespace Mindmath.Repository.Repository
{
	public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
	{
		public TransactionRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateTransaction(Transaction transaction) => Create(transaction);
		public async Task<Transaction> AddTransactionAsync(Transaction transaction)
		{
			return await CreateAsync(transaction);
		}

        public Task<Transaction?> GetTransactionByIdAsync(Guid id)
        {
            return FindByIdAsync(w => w.Id == id);
        }

        public async Task<Transaction?> GetSubjectById(Guid id, bool trackChange) => await FindByCondition(s => s.Id.Equals(id), trackChange).SingleOrDefaultAsync();
        public async Task<PagedList<Transaction>> GetTransactions(TransactionParameters transactionParameters, bool trackChange)
		{
			var transactions = FindAll(trackChange);
			return PagedList<Transaction>.ToPagedList(transactions, transactionParameters.PageNumber, transactionParameters.PageSize);
		}

		public async Task<PagedList<Transaction>> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange)
		{
			var transactions = FindByCondition(x => x.UserId == userId, trackChange);
			return PagedList<Transaction>.ToPagedList(transactions, transactionParameters.PageNumber, transactionParameters.PageSize);
		}
	}
}
