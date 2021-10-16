using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WidgetSnippet.GetAccessToken.Interfaces
{
    public interface IGetToken
    {
        string GetRefreshAndAccess(string id, string password);
    }
}
