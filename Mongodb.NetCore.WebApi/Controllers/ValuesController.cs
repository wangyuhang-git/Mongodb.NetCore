using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mongodb.NetCore.Interface;
using Mongodb.NetCore.Models.Entity.ManagePostAtt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.NetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IManagePostAtt<ManagePostAtt> _ManagePostAtt;
        private readonly ILogger<ValuesController> _Logger;

        public ValuesController(ILogger<ValuesController> logger, IManagePostAtt<ManagePostAtt> managePostAtt)
        {
            this._Logger = logger;
            this._ManagePostAtt = managePostAtt;
        }

        [HttpPost]
        public async Task<IEnumerable<ManagePostAtt>> GetPostAttAsync(string idCard)
        {
            //_Logger.LogInformation($"idCard：{idCard}");
            return await _ManagePostAtt.GetListAsync(c => c.IdCard == idCard);
        }


    }
}
