using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Validators;

namespace projeto_integrado_2_sem.Interactors
{
    class GenericPersister<T>
    {
        private BaseRepository<T> repository;
        private Validator<T>[] validators;

        public GenericPersister(BaseRepository<T> repo, Validator<T>[] validators)
        {
            this.repository = repo;
            this.validators = validators;
        }

        public bool persist(T record)
        {
            var results = validators.Select(v => v.Validate(record));
            if (results.All(r => r.Valid()))
            {
                repository.persist(record);
            } 
            
            return false;
        }
    }
}
