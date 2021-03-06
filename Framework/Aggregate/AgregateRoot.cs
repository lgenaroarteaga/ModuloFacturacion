﻿using System.Collections.Generic;
using System.Linq;

namespace Framework
{
    public abstract class AgregateRoot<TId> : IInternalEventHandler
        where TId : Value<TId>
    {
        public TId Id { get; protected set; }

        protected abstract void When(object @event);

        private readonly List<object> _changes;

        protected AgregateRoot() => _changes = new List<object>();

        protected void Apply(object @event)
        {
            When(@event);
            ValidateStatus();
            _changes.Add(@event);
        }

        public IEnumerable<object> GetChanges() => _changes.AsEnumerable();

        public void ClearChanges() => _changes.Clear();

        protected abstract void ValidateStatus();

        protected void ApplyToEntity(IInternalEventHandler entity, object @event)
            => entity?.Handle(@event);

        void IInternalEventHandler.Handle(object @event) => When(@event);
    }
}

