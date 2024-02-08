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
using System;
using System.Runtime.CompilerServices;
using DefaultEcs;

namespace Nazar
{
    public static class MessageBus
    {
        private static readonly World _world = new World();

        #region IPublisher

        /// <summary>
        /// Subscribes an <see cref="MessageHandler{T}"/> to be called back when a <typeparamref name="T"/> object is published.
        /// </summary>
        /// <typeparam name="T">The type of the object to be called back with.</typeparam>
        /// <param name="action">The delegate to be called back.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IDisposable Subscribe<T>(MessageHandler<T> action) => _world.Subscribe(action);

        /// <summary>
        /// Publishes a <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T">The type of the object to publish.</typeparam>
        /// <param name="message">The object to publish.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Publish<T>(in T message) => _world.Publish(message);

        #endregion

        #region IDisposable

        /// <summary>
        /// Cleans up all the components of existing <see cref="Entity"/>.
        /// The current <see cref="World"/>, all <see cref="Entity"/> and <see cref="EntitySet"/> created from this instance, should not be used again after calling this method.
        /// </summary>
        public static void Dispose()
        {
            _world.Dispose();
        }

        #endregion
    }
}
