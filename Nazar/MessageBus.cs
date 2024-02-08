using DefaultEcs;

namespace Nazar
{
    public static class MessageBus
    {
        private static readonly World _world = new World();

        public static void Publish<T>(in T message) where T : struct
        {
            _world.Publish(message);
        }

        public static void Subscribe<T>(object subscriber, Action<T> action) where T : struct
        {
            _world.Subscribe(subscriber, action);
        }

        public static void Unsubscribe(object subscriber)
        {
            _world.Unsubscribe(subscriber);
        }
    }
}
