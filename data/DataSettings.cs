using System;

namespace Dapanz.data
{
    [Serializable]
    public class DataSettings
    {
        public enum PersistenceType
        {
            DoNotPersist,
            ReadOnly,
            WriteOnly,
            ReadWrite,
        }

        public string dataTag = System.Guid.NewGuid().ToString();
        public PersistenceType persistenceType = PersistenceType.ReadWrite;

        public override string ToString()
        {
            return dataTag + " " + persistenceType.ToString();
        }
    }
}
