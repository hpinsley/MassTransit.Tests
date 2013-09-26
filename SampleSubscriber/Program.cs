using System;
using MassTransit;

namespace SampleSubscriber {
    class Program {
        static void Main() {
            Console.WriteLine("Start of subscriber");
            Console.WriteLine(@"Note that if you are using the subscription service, you must run C:\Source\MassTransit\src\MassTransit.RuntimeServices\bin\Debug\MassTransit.RuntimeServices.exe");

            Bus.Initialize(cfg => {
                cfg.ReceiveFrom("msmq://localhost/mytestqueuesub");
                //cfg.UseMsmq(mq => mq.UseMulticastSubscriptionClient());
                cfg.UseMsmq(mq => mq.UseSubscriptionService("msmq://localhost/mt_subscriptions"));
                cfg.VerifyMsDtcConfiguration();

                cfg.Subscribe(sbc => {
                    sbc.Consumer<TestMessageSubscriber>().Permanent();
                });
            });

            /*
            sbc.UseMsmq();
            sbc.UseMulticastSubscriptionClient();

            sbc.UseControlBus();

            sbc.Subscribe(subs => { subs.LoadFrom(container); });
            */

            //IServiceBus bus = Bus.Instance;
            
            //var unsubscribeDelegate = bus.SubscribeConsumer(() => new TestMessageSubscriber());

            Console.WriteLine("Set up subscriber");
            Console.WriteLine("Hit return to continue");
            Console.ReadLine();

            //Console.WriteLine("Unsubscribing");
            //bool unsubscribed = unsubscribeDelegate();
            //Console.WriteLine("Unsubscribe delegate returned {0}", unsubscribed);
        }
    }
}
