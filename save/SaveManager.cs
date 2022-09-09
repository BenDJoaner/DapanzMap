using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Dapanz
{
    public class SaveManager : ManagerBase
    {
        static SaveManagerData saveManagerData;

        static string saveDirPath;
        static string settingDirPath;

        static string saveDirName;
        static string settingDirName;

        static Dictionary<int, Dictionary<string, object>> cacheDic = new Dictionary<int, Dictionary<string, object>>();
        static BinaryFormatter binaryFormatter = new BinaryFormatter();

        static SaveManager()
        {
            saveDirPath = Application.persistentDataPath + "/" + saveDirName;
            settingDirPath = Application.persistentDataPath + "/" + settingDirName;
            // 确保路径的存在
            if (Directory.Exists(saveDirPath) == false)
            {
                Directory.CreateDirectory(saveDirPath);
            }
            if (Directory.Exists(settingDirPath) == false)
            {
                Directory.CreateDirectory(settingDirPath);
            }
            // 初始化SaveManagerData
            InitSaveManagerData();
        }


        private static void InitSaveManagerData()
        {
            saveManagerData = LoadFile<SaveManagerData>(saveDirPath + "/SaveMangerData");
            if (saveManagerData == null)
            {
                saveManagerData = new SaveManagerData();
                UpdateSaveManagerData();
            }
        }

        private static T LoadFile<T>(string v)
        {
            throw new NotImplementedException();
        }

        public static void UpdateSaveManagerData()
        {
            SaveFile(saveManagerData, saveDirPath + "/SaveMangerData");
        }

        public static List<SaveItem> GetAllSaveItemByUpdateTime()
        {
            List<SaveItem> saveItems = new List<SaveItem>(saveManagerData.saveItemList.Count);
            for (int i = 0; i < saveManagerData.saveItemList.Count; i++)
            {
                saveItems.Add(saveManagerData.saveItemList[i]);
            }
            OrderByUpdateTimeComparer orderBy = new OrderByUpdateTimeComparer();
            saveItems.Sort(orderBy);
            return saveItems;
        }


        private class OrderByUpdateTimeComparer : IComparer<SaveItem>
        {
            public int Compare(SaveItem x, SaveItem y)
            {
                if (x.lastSaveTime > y.lastSaveTime)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        private static void SetCache(int saveID, string fileName, object saveObject)
        {
            // 缓存字典中是否有这个SaveID
            if (cacheDic.ContainsKey(saveID))
            {
                // 这个存档中有没有这个文件
                if (cacheDic[saveID].ContainsKey(fileName))
                {
                    cacheDic[saveID][fileName] = saveObject;
                }
                else
                {
                    cacheDic[saveID].Add(fileName, saveObject);
                }
            }
            else
            {
                cacheDic.Add(saveID, new Dictionary<string, object>() { { fileName, saveObject } });
            }
        }

        public static void SaveObject(object saveObject, string saveFileName, SaveItem saveItem)
        {
            // 存档所在的文件夹路径
            string dirPath = GetSavePath(saveItem.saveID, true);
            // 具体的对象要保存的路径
            string savePath = dirPath + "/" + saveFileName;
            // 具体的保存
            SaveFile(saveObject, savePath);
            // 更新存档时间
            saveItem.UpdateTime(DateTime.Now);
            // 更新SaveManagerData 写入磁盘
            UpdateSaveManagerData();
            // 更新缓存
            SetCache(saveItem.saveID, saveFileName, saveObject);
        }

        private static string GetSavePath(int saveID, bool v = false)
        {
            throw new NotImplementedException();
        }

        public static T LoadObject<T>(string saveFileName, int saveID = 0) where T : class
        {
            T obj = GetCache<T>(saveID, saveFileName);
            if (obj == null)
            {
                // 存档所在的文件夹路径
                string dirPath = GetSavePath(saveID);
                if (dirPath == null) return null;
                // 具体的对象要保存的路径
                string savePath = dirPath + "/" + saveFileName;
                obj = LoadFile<T>(savePath);
                SetCache(saveID, saveFileName, obj);
            }
            return obj;
        }

        private static T GetCache<T>(int saveID, string saveFileName) where T : class
        {
            throw new NotImplementedException();
        }

        private static void SaveFile(object saveObject, string path)
        {
            FileStream f = new FileStream(path, FileMode.OpenOrCreate);
            // 二进制的方式把对象写进文件
            try
            {
                binaryFormatter.Serialize(f, saveObject);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                f.Flush();
                f.Close();
                f.Dispose();
            }
        }
    }
}
