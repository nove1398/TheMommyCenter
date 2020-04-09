 using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Client.Providers
{
    public class JSStorageProvider
    {
        private readonly IJSRuntime _jsRuntime;

        public JSStorageProvider(IJSRuntime js)
        {
            _jsRuntime = js;
        }

        public async Task SetItem(string key, string value)
        {
            await _jsRuntime.InvokeAsync<object>("localStorage.setItem", key, value);
        }

        public async Task<string> GetItem(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem",key);
        }
    }
}
