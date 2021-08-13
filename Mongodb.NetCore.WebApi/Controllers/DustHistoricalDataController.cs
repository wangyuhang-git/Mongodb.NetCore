using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mongodb.NetCore.Interface.DustHistoricalData;
using Mongodb.NetCore.Models;
using Mongodb.NetCore.Models.Entity.DustHistoricalData;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.NetCore.WebApi.Controllers
{
    /// <summary>
    /// 扬尘历史数据数据接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DustHistoricalDataController : ControllerBase
    {
        private readonly IDustHistoricalData<LTDQ_HistoryData> _dustHistoricalData;

        private readonly ILogger<DustHistoricalDataController> _logger;
        public DustHistoricalDataController(ILogger<DustHistoricalDataController> logger, IDustHistoricalData<LTDQ_HistoryData> dustHistoricalData)
        {
            this._dustHistoricalData = dustHistoricalData;
            this._logger = logger;
        }

        /// <summary>
        /// 批量添加扬尘历史数据
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost("AddManyAsync")]
        public async Task AddManyAsync([FromBody] dynamic values)
        {
            JObject @object = JObject.Parse(values.ToString());
            var list = @object.ToObject<BaseListModel<LTDQ_HistoryData>>();
            //_logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(list));
            if (null != list)
            {
                await _dustHistoricalData.AddManyAsync(list.List);
            }
        }


    }
}
