using System;
using MassTransit;

namespace Sample.Messages {
    [Serializable]
    public class EmailMessage : CorrelatedBy<Guid> {
        private Guid _correlationId;

        public Guid CorrelationId {
            get { return _correlationId; }
        }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public EmailMessage() {
            _correlationId = Guid.NewGuid();
        }

        public override string ToString() {
            return string.Format("Email from {0}.  Return address {1}", Name, EmailAddress);

        }
    }
}