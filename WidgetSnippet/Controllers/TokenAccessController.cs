using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WidgetSnippet.DTOs;
using WidgetSnippet.GetAccessToken;
using WidgetSnippet.GetAccessToken.Interfaces;

namespace WidgetSnippet.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[Controller]")]
    [ApiController]
    public class TokenAccessController : Controller
    {
        
        private readonly IGetToken _getToken;
        public TokenAccessController(IGetToken getToken)
        {            
            _getToken = getToken;
            
        }


        [HttpPost]
        public ActionResult<GetToken> GetApiKeys(ApiKeysDTO apiKeys)
        {
            var rest = _getToken.GetRefreshAndAccess(apiKeys.secretId, apiKeys.secretPassword);

            GetToken keys = JsonSerializer.Deserialize<GetToken>(rest);

            return keys;
        }

        
    }
}
