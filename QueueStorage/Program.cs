// See https://aka.ms/new-console-template for more information
using Azure.Storage.Queues;
using Console;
using UserSecrets;

QueueRepository queueRepository = new QueueRepository();

queueRepository.CreateQueue();
queueRepository.InsertMessage("testing message");
queueRepository.PeekMessage();
queueRepository.UpdateMessage();
queueRepository.PeekMessage();
queueRepository.DequeueMessage();