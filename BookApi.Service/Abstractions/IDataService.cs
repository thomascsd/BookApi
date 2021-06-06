using AirtableApiClient;
using BookApi.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Service.Abstractions
{
    public interface IDataService
    {
        Task<IEnumerable<T>> GetDatas<T>(string baseId, string tableName) where T : BaseModel;

        Task<AirtableCreateUpdateReplaceRecordResponse> SaveData<T>(string baseId, string tableName, T data) where T : BaseModel;

        Task<AirtableCreateUpdateReplaceRecordResponse> UpdateData<T>(string baseId, string tableName, T data) where T : BaseModel;

        Task<AirtableDeleteRecordResponse> DeleteData(string baseId, string tableName, string id);
    }
}