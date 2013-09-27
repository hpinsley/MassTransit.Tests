using System;
using MassTransit;
using Sample.Messages;

namespace SampleSubscriber {
    public class EmailSubscriber : Consumes<EmailMessage>.All {
        public void Consume(EmailMessage emailMessage) {
            Console.WriteLine("Email Message Processed: {0}", emailMessage);
        }
    }
}