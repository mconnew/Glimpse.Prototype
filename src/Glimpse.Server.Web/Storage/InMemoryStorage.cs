﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glimpse.Server
{
    public class InMemoryStorage : IStorage
    {
        private readonly IList<IMessageEnvelope> _store;

        public InMemoryStorage()
        {
            _store = new List<IMessageEnvelope>();
        }

        public async Task Persist(IMessageEnvelope message)
        {
            await Task.Run(() => _store.Add(message));
        }

        public IEnumerable<IMessageEnvelope> AllMessages
        {
            get { return _store; }
        }
    }
}