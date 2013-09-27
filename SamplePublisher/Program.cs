using System;
using MassTransit;
using Sample.Messages;

namespace SamplePublisher {
    class Program {
        static void Main() {
            Console.WriteLine("Start of publisher");

            Bus.Initialize(cfg => {
                cfg.ReceiveFrom("msmq://localhost/mytestqueue");
                cfg.UseMsmq(mq => mq.UseMulticastSubscriptionClient());
                cfg.VerifyMsDtcConfiguration();
            });
            
            IServiceBus bus = Bus.Instance;
            for (;;) {
                Console.Write("Messsage: ");
                string text = Console.ReadLine();
                if (string.IsNullOrEmpty(text))
                    break;

                var msg = new TestMessage {Name = text};
                bus.Publish(msg);
            }
        }
    }
}
