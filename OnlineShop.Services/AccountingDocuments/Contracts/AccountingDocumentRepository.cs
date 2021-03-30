using OnlineShop.Entities;

namespace OnlineShop.Services.AccountingDocuments.Contracts
{
    public interface AccountingDocumentRepository
    {
        void Add(AccountingDocument accountingDocument);
    }
}