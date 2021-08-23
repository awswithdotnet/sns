namespace Abstractions
{
    public interface IPublisher<TMessage, TOut>
    {
        TOut Publish(TMessage message);
    }
}