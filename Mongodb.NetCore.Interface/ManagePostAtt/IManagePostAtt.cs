using Mongodb.NetCore.Models.Entity.ManagePostAtt;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mongodb.NetCore.Interface
{
    /// <summary>
    /// 管理人员岗位信息
    /// </summary>
    public interface IManagePostAtt<T> where T : class
    {
        Task AddManyAsync(IEnumerable<T> list);

        Task<IEnumerable<T>> GetListAsync(Func<T, bool> func);
    }
}
