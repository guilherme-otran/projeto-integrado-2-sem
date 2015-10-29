using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Validators;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Casters;

namespace projeto_integrado_2_sem.Interactors
{
    class GenericPersister<T> where T : IStorable
    {
        private BaseRepository<T> repository;
        private Validator<T>[] validators;
        private GenericTypeCaster<T> caster;

        public GenericPersister(BaseRepository<T> repo, Validator<T>[] validators, GenericTypeCaster<T> caster)
        {
            this.repository = repo;
            this.validators = validators;
            this.caster = caster;
        }

        public GenericTypeCaster<T> GetCaster()
        {
            return this.caster;
        }

        public ValidationResult CasterErrors()
        {
            return this.caster.GetResult();
        }

        public ValidationResult ValidatorErrors(Validator<T> validator)
        {
            var record = caster.GetModel();
            return validator.Validate(record);
        }

        public bool Persist()
        {
            var record = caster.GetModel();
            var results = validators.Select(v => v.Validate(record));

            var castValid = caster.Valid();
            var validation = results.All(r => r.Valid());

            if (castValid && validation)
            {
                repository.persist(record);
                return true;
            } 
            
            return false;
        }
    }
}
