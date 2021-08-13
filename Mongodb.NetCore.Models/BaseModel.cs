using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb.NetCore.Models
{
    [BsonIgnoreExtraElements]
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement(nameof(Id))]
        public string Id { get; set; }

        [BsonElement(nameof(CreateTime))]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public virtual DateTime? CreateTime { get; set; }

        [BsonElement(nameof(IsDelete))]
        public bool IsDelete { get; set; }

        public BaseModel()
        {
            this.CreateTime = DateTime.Now;
            this.IsDelete = false;
        }
    }
}
