using AirtableApiClient;
using BookApi.DataAccess;
using BookApi.Service.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Service.Impls
{
    public class DataService : IDataService
    {
        private string m_ApiKey;

        public DataService(IConfiguration configuration)
        {
            this.m_ApiKey = configuration.GetValue<string>("AirTable:ApiKey");
        }

        public async Task<IEnumerable<T>> GetDatas<T>(string baseId, string tableName) where T : BaseModel
        {
            string offset = null;
            List<T> datas = new List<T>();
            List<AirtableRecord<T>> records = new List<AirtableRecord<T>>();
            AirtableListRecordsResponse<T> res;

            using (AirtableBase airtable = new AirtableBase(this.m_ApiKey, baseId))
            {
                do
                {
                    res = await airtable.ListRecords<T>(tableName, offset);
                    records.AddRange(res.Records);
                    offset = res.Offset;
                } while (offset != null);
            }

            datas = records
                .Select(m =>
                {
                    m.Fields.Id = m.Id;
                    return m.Fields;
                })
                .ToList();

            return datas;
        }

        public async Task<AirtableCreateUpdateReplaceRecordResponse> SaveData<T>(string baseId, string tableName, T data) where T : BaseModel
        {
            var fields = this.GetFields<T>(data);
            AirtableCreateUpdateReplaceRecordResponse res;

            using (AirtableBase airTable = new AirtableBase(this.m_ApiKey, baseId))
            {
                await airTable.CreateRecord(tableName, fields);
            }

            return res;
        }

        public async Task<AirtableCreateUpdateReplaceRecordResponse> UpdateData<T>(string baseId, string tableName, T data) where T : BaseModel
        {
            var fields = this.GetFields<T>(data);
            AirtableCreateUpdateReplaceRecordResponse res;

            using (AirtableBase airTable = new AirtableBase(this.m_ApiKey, baseId))
            {
                res = await airTable.UpdateRecord(tableName, fields, data.Id);
            }

            return res;
        }

        public async Task<AirtableDeleteRecordResponse> DeleteData(string baseId, string tableName, string id)
        {
            AirtableDeleteRecordResponse res;

            using (AirtableBase airTable = new AirtableBase(this.m_ApiKey, baseId))
            {
                res = await airTable.DeleteRecord(tableName, id);
            }

            return res;
        }

        private Fields GetFields<T>(T data) where T : BaseModel
        {
            var dic = new Dictionary<string, object>();
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                object value = prop.GetValue(data);
                dic.Add(prop.Name, value);
            }

            var fields = new Fields
            {
                FieldsCollection = dic
            };

            return fields;
        }
    }
}