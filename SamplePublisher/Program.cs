using System;
using MassTransit;
using Sample.Messages;

namespace SamplePublisher {
    class Program {
        static void Main() {

            Console.WriteLine("Start of publisher");

            Bus.Initialize(cfg => {
                cfg.ReceiveFrom("msmq://localhost/mytestqueue");
                //cfg.UseMsmq(mq => mq.UseMulticastSubscriptionClient());
                cfg.UseMsmq(mq => mq.UseSubscriptionService("msmq://localhost/mt_subscriptions"));
                cfg.VerifyMsDtcConfiguration();
            });
            
            Console.WriteLine("Sleeping before publishing");
            System.Threading.Thread.Sleep(15000);
            Console.WriteLine("Writing the message");
            IServiceBus bus = Bus.Instance;
            bus.Publish(new TestMessage());
            Console.WriteLine("Published message");
            Console.WriteLine("Hit return to continue");
            Console.ReadLine();
        }
    }
}
