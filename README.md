[← Return to AZ-204](README.md)<br> 

[![.NET](https://github.com/joerivanarkel/AzureQueueStorage/actions/workflows/dotnet.yml/badge.svg)](https://github.com/joerivanarkel/AzureQueueStorage/actions/workflows/dotnet.yml)

# AzureQueueStorage
In this example i am Storing, Fetching, Peeking and Updating messages in Azure Queue Storage. To interact with Queue Storage, i've used the `Azure.Storage.Queues` NuGet package ans using dotnet secrets to hide the connection string formt he source code.

## Creating a Queue
To excute any commands from code to Queue storage, you will have to use the `QueueClient` class. When creating this class, you have to provide a connection string and a queue name. Then i'll ensure that this QueueClient exists remote, by running the `CreateIfNotExists()` method.

```csharp
_queueClient.CreateIfNotExists();
```

## Sending a Message to a Queue
To send/insert a message to a Queue, you'll have to use the `SendMessage()` method. This method takes a parameter of a string to insert as the body of the message.

```csharp
_queueClient.SendMessage(message);
```

## Peeking a Message from a Queue
Fetching/peeking a message from a Queue can be accomplished with the `PeekMessages()`. This returns an array of the PeekedMessage type.

```csharp
PeekedMessage[] peekedMessage = _queueClient.PeekMessages();
```

## Updating a Message
To update a message, you must first fetch/peek a message. Then you are able to use the `UpdateMessage()`. This method takes the MessageId, PopReceipt, the new message and a TimeSpan of invisibility for the message.

```csharp
QueueMessage[] message = _queueClient.ReceiveMessages();
_queueClient.UpdateMessage(message[0].MessageId,
  message[0].PopReceipt,
  "Updated contents",
  TimeSpan.FromSeconds(60.0)
);
```
