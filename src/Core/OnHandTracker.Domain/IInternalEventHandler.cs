namespace OnHandTracker.Domain
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}