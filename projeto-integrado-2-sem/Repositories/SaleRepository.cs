using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Repositories
{
    public class SaleRepository : ExclusionBaseRepository<Sale>
    {
        private ProductRepository prodRepo;
        private CustomerRepository custRepo;

        public SaleRepository(ProductRepository prodRepo, CustomerRepository custRepo) : base("sales.dat", "dead-sales.dat")
        {
            this.prodRepo = prodRepo;

            this.custRepo = custRepo;
            this.custRepo.DestroyRecords += CustRepo_DestroyRecord;
        }

        private void CustRepo_DestroyRecord(object sender, BaseRepository<Customer>.DestroyRecordsEventArgs e)
        {
            var salesPerCustomer = e.FindedStorables.Select(customer => FindManyWithCustomerId(customer.Id));
            var sales = salesPerCustomer.Aggregate((acc, curr) => acc.Union(curr).ToList());
            DestroyMany(sales);
        }

        public override void InitComponents()
        {
            base.InitComponents();
            var saleAdapt = (SaleStorableAdapter)StorableAdapter;
            saleAdapt.custRepo = custRepo;
            saleAdapt.prodRepo = prodRepo;
        }

        public override void InitializeFile()
        {
            InitializeFile(new SaleStorableAdapter());
        }

        public IList<Sale> FindManyWithCustomerId(string customerId)
        {
            return FindManyWith(s => s.CustomerId.Equals(customerId));
        }

        public IEnumerable<SaleGroup<TGroupKeyResult>> GroupedBy<TGroupKeyResult>(Func<Sale, TGroupKeyResult> groupFn)
        {
            return FindManyWith(c => true)
                .GroupBy(node => groupFn(node))
                .Select(g => new SaleGroup<TGroupKeyResult>(g.Key, g.ToList()));
        }
    }
}
