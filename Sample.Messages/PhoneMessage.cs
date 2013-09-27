using System;
using MassTransit;

namespace Sample.Messages {

    [Serializable]
    public class PhoneMessage : CorrelatedBy<Guid> {
        private Guid _correlationId;

        public Guid CorrelationId {
            get { return _correlationId; }
        }
        public string Name { get; set; }
        public DateTime Received { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneMessage() {
            _correlationId = Guid.NewGuid();
        }

        public override string ToString() {
            return string.Format("Phone call from {0} at {1}.  Callback {2}", Name, Received, PhoneNumber);
        }
    }
}
