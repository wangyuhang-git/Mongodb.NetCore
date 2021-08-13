using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb.NetCore.Models.Entity.DustHistoricalData
{
    /// <summary>
    /// 扬尘历史数据
    /// </summary>
    [Serializable]
    public class LTDQ_HistoryData : BaseModel
    {
        [BsonElement("CreateDate")]//属性重命名
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        public string DeviceSN { get; set; }

        /// <summary>
        /// PM2.5(ug/m³)
        /// </summary>
        public float pm25 { get; set; }

        /// <summary>
        /// PM10(ug/m³)
        /// </summary>
        public float pm10 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? tsp { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        public float? pd04 { get; set; }

        /// <summary>
        /// 湿度
        /// </summary>
        public float? pd05 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? pd06 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? pd07 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? pd08 { get; set; }

        /// <summary>
        /// 噪音(dB)
        /// </summary>
        public float? pd09 { get; set; }

        /// <summary>
        /// 数据源类型
        /// </summary>
        public string LTcontent { get; set; }

        /// <summary>
        /// 项目GUID
        /// </summary>
        public string ProjectGUID { get; set; }

        /// <summary>
        /// 是否已经数据交换过
        /// </summary>
        public int? IsTransfer { get; set; }
    }
}
