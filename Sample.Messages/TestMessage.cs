using System;
using MassTransit;

namespace Sample.Messages {

    [Serializable]
    public class TestMessage : CorrelatedBy<Guid> {
        private Guid _correlationId;

        public Guid CorrelationId {
            get { return _correlationId; }
        }
        public string Name { get; set; }

        public TestMessage() {
            _correlationId = Guid.NewGuid();
        }

    }
}
