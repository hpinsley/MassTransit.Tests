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
                char command = text.ToLower()[0];
                string name = text.Substring(1);

                switch (command) {
                    case 'e':
                        var emailMessage = new EmailMessage { Name = name, EmailAddress = "noreply@nowhere.com" };
                        bus.Publish(emailMessage);
                        break;
                    case 'p':
                        var phoneMessage = new PhoneMessage {Name = name, Received = DateTime.Now, PhoneNumber = "(212) 555-1212"};
                        bus.Publish(phoneMessage);
                        break;
                    default:
                        Console.WriteLine("Preceed message with e for email or p for phone call.");
                        break;
                }
            }
        }
    }
}
