using Mongodb.NetCore.Interface.DustHistoricalData;
using Mongodb.NetCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb.NetCore.Business.DustHistoricalData
{
    public class DustHistoricalDataBusiness<T> : IDustHistoricalData<T>
        where T : class
    {
        MongodbService<T> service = new Service.MongodbService<T>(typeof(T).Name);

        public async Task AddManyAsync(IEnumerable<T> list)
        {
            await service.AddManyAsync(list);
        }

        public async Task<IEnumerable<T>> GetListAsync(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
