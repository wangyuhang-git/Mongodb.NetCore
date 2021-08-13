using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb.NetCore.Interface.DustHistoricalData
{
    /// <summary>
    /// 扬尘历史数据接口
    /// </summary>
    public interface IDustHistoricalData<T> where T : class
    {
        Task AddManyAsync(IEnumerable<T> list);

        Task<IEnumerable<T>> GetListAsync(Func<T, bool> func);
    }
}
