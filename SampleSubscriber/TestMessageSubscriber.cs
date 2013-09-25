using System;
using MassTransit;
using Sample.Messages;

namespace SampleSubscriber {
    public class TestMessageSubscriber : Consumes<TestMessage>.All {
        public TestMessageSubscriber() {
            Console.WriteLine("In TestMessageSubscriber constructor");
        }

        public void Consume(TestMessage message) {
            Console.WriteLine("Received message: {0}/{1}", message.CorrelationId, message.Name);

        }
    }
}