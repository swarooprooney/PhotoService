using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoServiceApi.Datalayer
{
    public interface IDatabaseWrapper
    {
        Task<List<T>> GetAllRecordsAsync<T>(string table);
        Task<T> GetRecordByIdAsync<T>(string table, Guid guid);
        Task<bool> TryInsertNewRecordAsync<T>(string table, T record);
        Task<bool> UpdateRecord<T>(string table, Guid guid, T record);
    }
}