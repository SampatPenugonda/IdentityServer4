﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Threading.Tasks;

namespace IdentityServer4.Stores
{
    internal class ConsentMessageStore : IConsentMessageStore
    {
        protected readonly MessageCookie<ConsentResponse> _cookie;

        public ConsentMessageStore(MessageCookie<ConsentResponse> cookie)
        {
            _cookie = cookie;
        }

        public virtual Task DeleteAsync(string id)
        {
            _cookie.Clear(id);
            return Task.FromResult(0);
        }

        public virtual Task<Message<ConsentResponse>> ReadAsync(string id)
        {
            return Task.FromResult(_cookie.Read(id));
        }

        public virtual Task WriteAsync(string id, Message<ConsentResponse> message)
        {
            _cookie.Write(id, message);
            return Task.FromResult(0);
        }
    }
}
