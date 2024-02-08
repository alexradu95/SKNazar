using DefaultEcs;
using System;

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
            // This method should be removed as it does not match the DefaultEcs API.
        }

        public static void Unsubscribe(object subscriber)
        {
            foreach (var subscription in _subscriptions)
            {
                    subscription.();
            }
            _subscriptions.RemoveAll(sub => sub.Subscriber == subscriber);
        }
        private static List<(IDisposable Subscription, object Subscriber)> _subscriptions = new List<(IDisposable, object)>();

        public static IDisposable Subscribe<T>(object subscriber, Action<T> action) where T : struct
        {
            var subscription = _world.Subscribe<T>(action);
            _subscriptions.Add(subscription);
            return subscription;
        }
    }
}
