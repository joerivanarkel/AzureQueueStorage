// See https://aka.ms/new-console-template for more information
using Azure.Storage.Queues;
using Console;

string connectionString = DatabaseConnection<Program>.GetSecret("connectionstring");
QueueClient queueClient = new QueueClient(connectionString, "testqueue");

QueueRepository queueRepository = new QueueRepository(queueClient);

queueRepository.CreateQueue();
queueRepository.InsertMessage("testing message");
queueRepository.PeekMessage();
queueRepository.UpdateMessage();
queueRepository.PeekMessage();
queueRepository.DequeueMessage();