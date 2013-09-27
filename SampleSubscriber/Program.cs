using System;
using MassTransit;
using MassTransit.SubscriptionConfigurators;

namespace SampleSubscriber {
    class Program {
        static int Main(string[] args) {
            Console.WriteLine("Start of subscriber");
            Console.WriteLine(@"Note that if you are using the subscription service, you must run C:\Source\MassTransit\src\MassTransit.RuntimeServices\bin\Debug\MassTransit.RuntimeServices.exe");
            Console.WriteLine("If you are using UseMulticastSubscriptionClient then you have to install multicast support (in Message Queueing) window feature.");

            if (args.Length != 1) {
                Usage();
                return 1;
            }

            int subscriberNumber = int.Parse(args[0]);
            string subscriberQueue = string.Format("msmq://localhost/mytestqueuesub_{0}", subscriberNumber);
            Console.WriteLine("Subscriber queue will be {0}", subscriberQueue);

            Bus.Initialize(cfg => {
                cfg.ReceiveFrom(subscriberQueue);
                cfg.UseMsmq(mq => mq.UseMulticastSubscriptionClient());
                cfg.VerifyMsDtcConfiguration();

                cfg.Subscribe(sbc => {
                    sbc.Consumer<PhoneCallSubscriber>();
                });
                cfg.Subscribe(sbc => {
                    sbc.Consumer<EmailSubscriber>();
                });
            });

            Console.WriteLine("Set up subscriber {0}", subscriberNumber);
            Console.WriteLine("Hit return to continue");
            Console.ReadLine();

            return 0;
        }

        private static void Usage() {
            Console.WriteLine("Usage: {0} <subscriber number>", AppDomain.CurrentDomain.FriendlyName);
        }
    }
}