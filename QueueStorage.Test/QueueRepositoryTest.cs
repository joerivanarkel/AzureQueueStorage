using Azure.Storage.Queues;
using Console;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace QueueStorage.Test;

public class QueueRepositoryTest
{
    [Fact]
    public void ShouldCreateQueue()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        var mockconnectionstring = fixture.Create<string>();
        var mockqueuename = fixture.Create<string>();
        QueueClient queueClient = fixture.Create<QueueClient>();
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.CreateQueue();
        Assert.True(result);
    }

    [Fact]
    public void ShouldInsertMessage()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        QueueClient queueClient = fixture.Create<QueueClient>();
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.InsertMessage("testing message");
        Assert.True(result);
    }

    [Fact]
    public void ShouldPeekMessage()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        QueueClient queueClient = fixture.Create<QueueClient>();
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.PeekMessage();
        Assert.True(result);
    }

    [Fact]
    public void ShouldUpdateMessage()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        QueueClient queueClient = fixture.Create<QueueClient>();
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.UpdateMessage(1);
        Assert.True(result);
    }

    [Fact]
    public void ShouldDequeueMessage()
    {
        Fixture fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        QueueClient queueClient = fixture.Create<QueueClient>();
        QueueRepository queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.DequeueMessage(1);
        Assert.True(result);
    }
}