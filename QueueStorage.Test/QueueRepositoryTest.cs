using System.Data;
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
using Microsoft.Extensions.Configuration;

namespace QueueStorage.Test;

public class QueueRepositoryTest
{
    string connectionString;

    public QueueRepositoryTest()
    {
        connectionString = DatabaseConnection<QueueRepositoryTest>.GetSecret("connectionstring");
        if (connectionString == null)
        {
            connectionString = "REPLACE";
        }
    }

    [Fact]
    public void ShouldCreateQueue()
    {
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.CreateQueue();
        Assert.True(result);
    }

    [Fact]
    public void ShouldInsertMessage()
    {
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.InsertMessage("testing message");
        Assert.True(result);
    }

    [Fact]
    public void ShouldPeekMessage()
    {
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.PeekMessage();
        Assert.True(result);
    }

    [Fact]
    public void ShouldUpdateMessage()
    {
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.UpdateMessage();
        Assert.True(result);
    }

    [Fact]
    public void ShouldDequeueMessage()
    {
        QueueClient queueClient = new QueueClient(connectionString, "testqueue");
        QueueRepository queueRepository = new QueueRepository(queueClient);

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.DequeueMessage();
        Assert.True(result);
    }
}