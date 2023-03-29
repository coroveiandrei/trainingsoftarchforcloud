using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDCqrsEs.Persistance
{
    public interface ITableStorageConnection
    {
        public Task<CloudTable> CreateConnection(string tableName);
    }
}
