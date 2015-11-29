using projeto_integrado_2_sem.Models;
using System;

namespace projeto_integrado_2_sem.Repositories
{
    public abstract class ExclusionBaseRepository<T> : BaseRepository<T> where T : IStorable
    {
        public class DeadRepository : BaseRepository<T>
        {
            public DeadRepository(string fileName) : base(fileName) { }

            public override void InitializeFile()
            {
                throw new NotImplementedException();
            }

            public new T FindBy(Func<T, Boolean> func)
            {
                return base.FindBy(func);
            }
        }

        private DeadRepository deadFileRepository;

        public ExclusionBaseRepository(string fileName, string deadFileName) : base(fileName)
        {
            deadFileRepository = new DeadRepository(deadFileName);
            this.DestroyRecords += ExclusionBaseRepository_DestroyRecords;
        }

        private void ExclusionBaseRepository_DestroyRecords(object sender, DestroyRecordsEventArgs e)
        {
            deadFileRepository.PersistMany(e.FindedStorables);
        }

        public override void InitializeFile(IStorableAdapter<T> storableAdapter)
        {
            deadFileRepository.InitializeFile(storableAdapter);
            base.InitializeFile(storableAdapter);
        }

        public override void InitComponents()
        {
            base.InitComponents();
            deadFileRepository.InitComponents();
        }

        public override void Close()
        {
            base.Close();
            deadFileRepository.Close();
        }

        public DeadRepository DeadRecordsRepo()
        {
            return deadFileRepository;
        }
    }
}
