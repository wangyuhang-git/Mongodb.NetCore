using Mongodb.NetCore.Interface;
using Mongodb.NetCore.Models.Entity.ManagePostAtt;
using Mongodb.NetCore.Service;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mongodb.NetCore.Business
{
    public class ManagePostAttBusiness<T> : IManagePostAtt<T>
        where T : class
    {
        MongodbService<T> mongodbService = new Service.MongodbService<T>(typeof(T).Name);

        public async Task AddManyAsync(IEnumerable<T> list)
        {
            //throw new NotImplementedException();
            await mongodbService.AddManyAsync(list);
        }

        public async Task<IEnumerable<T>> GetListAsync(Func<T, bool> func)
        {
            return await mongodbService.GetListAsync(func);
        }
    }

}
