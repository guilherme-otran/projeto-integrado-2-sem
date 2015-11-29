using projeto_integrado_2_sem.Casters;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Interactors
{
    class SalePersister : GenericPersister<Sale>
    {
        private ProductRepository prodRepo;

        public SalePersister(SaleRepository repo, ProductRepository prodRepo, SaleValidator validator, SaleCaster caster) : 
            base(repo, new SaleValidator[] { validator }, caster)
        {
            this.prodRepo = prodRepo;
        }

        public override bool Persist()
        {
            var record = GetCaster().GetModel();

            if (base.Persist())
            {
                record.Product.Amount -= record.Quantity.Value;
                prodRepo.Persist(record.Product);
                return true;
            }
            
            return false;
        }

    }
}
