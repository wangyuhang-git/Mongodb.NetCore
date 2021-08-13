using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb.NetCore.Models
{
    public class BaseListModel<T> where T : class
    {
        public List<T> List { get; set; }
    }
}
