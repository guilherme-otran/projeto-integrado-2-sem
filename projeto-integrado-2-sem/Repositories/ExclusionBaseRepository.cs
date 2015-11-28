using projeto_integrado_2_sem.Models;
using System;

namespace projeto_integrado_2_sem.Repositories
{
    public abstract class ExclusionBaseRepository<T> : BaseRepository<T> where T : IStorable
    {
        private class DeadRepository : BaseRepository<T>
        {
            public DeadRepository(string fileName) : base(fileName) { }

            public override void InitializeFile()
            {
                throw new NotImplementedException();
            }
        }

        private DeadRepository deadFileRepository;

        public ExclusionBaseRepository(string fileName, string deadFileName) : base(fileName)
        {
            deadFileRepository = new DeadRepository(deadFileName);
            this.DestroyRecord += ExclusionBaseRepository_DestroyRecord;
        }

        private void ExclusionBaseRepository_DestroyRecord(object sender, DestroyRecordEventArgs e)
        {
            deadFileRepository.Persist(e.FindedStorable);
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

        public BaseRepository<T> DeadRecordsRepo()
        {
            return deadFileRepository;
        }
    }
}
