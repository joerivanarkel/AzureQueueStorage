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
        var fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        var queueClient = fixture.Create<QueueClient>();
        var queueRepository = new QueueRepository(queueClient);

        var result = queueRepository.CreateQueue();
        Assert.True(result);
    }

    [Fact]
    public void ShouldInsertMessage()
    {
        var fixture = new Fixture();
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

        var result = queueRepository.PeekMessage(1);
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