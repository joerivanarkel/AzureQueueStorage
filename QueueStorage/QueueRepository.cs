using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace Console
{
    public class QueueRepository
    {
        private QueueClient _queueClient;

        public QueueRepository(QueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public bool CreateQueue()
        {
            try
            {
                // Create the queue
                _queueClient.CreateIfNotExists();

                if (_queueClient.Exists())
                {
                    System.Console.WriteLine($"Queue created: '{_queueClient.Name}'");
                    return true;
                }
                else
                {
                    System.Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Exception: {ex.Message}\n\n");
                System.Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }

        public bool InsertMessage(string message)
        {
            try
            {
                _queueClient.SendMessage(message);
                System.Console.WriteLine($"Inserted: {message}");
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Exception: {ex.Message}\n\n");
                System.Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }

        public bool PeekMessage()
        {
            try
            {
                PeekedMessage[] peekedMessage = _queueClient.PeekMessages();
                System.Console.WriteLine($"Peeked message: '{peekedMessage[0].Body}'");
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Exception: {ex.Message}\n\n");
                System.Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }

        public bool UpdateMessage()
        {
            try
            {
                QueueMessage[] message = _queueClient.ReceiveMessages();
                _queueClient.UpdateMessage(message[0].MessageId,
                    message[0].PopReceipt,
                    "Updated contents",
                    TimeSpan.FromSeconds(60.0)  // Make it invisible for another 60 seconds
                );
                System.Console.WriteLine($"Updated message: '{message[0].Body}'");
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Exception: {ex.Message}\n\n");
                System.Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }

        public bool DequeueMessage()
        {
            try
            {
                QueueMessage[] retrievedMessage = _queueClient.ReceiveMessages();
                System.Console.WriteLine($"Dequeued message: '{retrievedMessage[0].Body}'");
                _queueClient.DeleteMessage(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Exception: {ex.Message}\n\n");
                System.Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }
    }
}