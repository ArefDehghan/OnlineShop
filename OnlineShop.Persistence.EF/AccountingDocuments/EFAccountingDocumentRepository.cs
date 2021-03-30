using OnlineShop.Entities;
using OnlineShop.Services.AccountingDocuments.Contracts;

namespace OnlineShop.Persistence.EF.AccountingDocuments
{
    public class EFAccountingDocumentRepository : AccountingDocumentRepository
    {
        private readonly EFDataContext _context;
        public EFAccountingDocumentRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(AccountingDocument accountingDocument)
        {
            _context.AccountingDocuments.Add(accountingDocument);
        }
    }
}