using System;
using System.Collections.Generic;
using System.Text;

namespace DapanzSceneTools
{
    public interface IDataPersister
    {
        DataSettings GetDataSettings();

        void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType);

        Data SaveData();

        void LoadData(Data data);
    }
}
