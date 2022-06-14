using System;

namespace Sale.Core.Messages
{
    public abstract class Event
    {
        public Guid AggregateRootId { get; protected set; }
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}