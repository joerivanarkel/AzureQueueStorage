using Azure.Storage.Queues;
using Console;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Azure;
using Azure.Storage.Queues.Models;
using System.Threading;
using System;
using System.Reflection;

namespace QueueStorage.Test;

public class QueueRepositoryTest
{
    [Fact]
    public void ShouldCreateQueue()
    {
        string connectionString = DatabaseConnection<QueueRepositoryTest>.GetSecret("connectionstring");
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.CreateQueue();
        Assert.True(result);
    }

    [Fact]
    public void ShouldInsertMessage()
    {
        string connectionString = DatabaseConnection<QueueRepositoryTest>.GetSecret("connectionstring");
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.InsertMessage("testing message");
        Assert.True(result);
    }

    [Fact]
    public void ShouldPeekMessage()
    {
        string connectionString = DatabaseConnection<QueueRepositoryTest>.GetSecret("connectionstring");
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.PeekMessage();
        Assert.True(result);
    }

    [Fact]
    public void ShouldUpdateMessage()
    {
        string connectionString = DatabaseConnection<QueueRepositoryTest>.GetSecret("connectionstring");
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.UpdateMessage();
        Assert.True(result);
    }

    [Fact]
    public void ShouldDequeueMessage()
    {
        string connectionString = DatabaseConnection<QueueRepositoryTest>.GetSecret("connectionstring");
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.DequeueMessage();
        Assert.True(result);
    }
}