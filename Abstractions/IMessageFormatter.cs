namespace Abstractions
{
    public interface IMessageFormatter<TIn, TOut>
    {
        TOut Format(TIn message);
    }
}