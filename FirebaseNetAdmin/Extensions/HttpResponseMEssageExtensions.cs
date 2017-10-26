﻿using System.Net.Http;
using System.Threading.Tasks;
using FirebaseNetAdmin.Exceptions;

namespace FirebaseNetAdmin.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            var content = await response.Content.ReadAsStringAsync();

            response.Content?.Dispose();

            throw new FirebaseHttpException(content, response.RequestMessage, response);
        }
    }
}
