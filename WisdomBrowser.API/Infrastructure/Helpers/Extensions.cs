﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WisdomBrowser.API.Infrastructure.Helpers
{
    public static class Extensions
    {
        public static void AddAplicationError(this HttpResponse httpResponse, string message)
        {
            httpResponse.Headers.Add("Application-Error", message);
            httpResponse.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            httpResponse.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
