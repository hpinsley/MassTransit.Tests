using System;
using MassTransit;
using Sample.Messages;

namespace SampleSubscriber {
    public class PhoneCallSubscriber : Consumes<PhoneMessage>.All {
        public void Consume(PhoneMessage phoneMessage) {
            Console.WriteLine("Phone Message Processed: {0}", phoneMessage);
        }
    }
}