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
using UserSecrets;

namespace QueueStorage.Test;

public class QueueRepositoryTest
{
    [Fact]
    public void ShouldCreateQueue()
    {
        QueueRepository queueRepository = new QueueRepository();

        var result = queueRepository.CreateQueue();
        Assert.True(result);
    }

    [Fact]
    public void ShouldInsertMessage()
    {
        QueueRepository queueRepository = new QueueRepository();

        var result = queueRepository.InsertMessage("testing message");
        Assert.True(result);
    }

    [Fact]
    public void ShouldPeekMessage()
    {
        QueueRepository queueRepository = new QueueRepository();

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.PeekMessage();
        Assert.True(result);
    }

    [Fact]
    public void ShouldUpdateMessage()
    {
        QueueRepository queueRepository = new QueueRepository();

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.UpdateMessage();
        Assert.True(result);
    }

    [Fact]
    public void ShouldDequeueMessage()
    {
        QueueRepository queueRepository = new QueueRepository();

        queueRepository.InsertMessage("testing message");
        var result = queueRepository.DequeueMessage();
        Assert.True(result);
    }
}