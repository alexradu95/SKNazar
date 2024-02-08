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

        public static void Subscribe<T>(object subscriber) where T : struct
        {
            _world.Subscribe<T>(subscriber);
        }

        public static void Unsubscribe(object subscriber)
        {
            foreach (var subscription in _subscriptions)
            {
                    subscription.Dispose();
            }
            _subscriptions.RemoveAll(sub => sub.Subscriber == subscriber);
        }
        private static List<IDisposable> _subscriptions = new List<IDisposable>();

        public static IDisposable Subscribe<T>(object subscriber, Action<T> action) where T : struct
        {
            var subscription = _world.Subscribe(subscriber, action);
            _subscriptions.Add(subscription);
            return subscription;
        }
    }
}
