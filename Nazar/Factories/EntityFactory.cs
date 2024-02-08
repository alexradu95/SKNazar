using DefaultEcs;
using Nazar.Components;

namespace Nazar.Factories
{
    /// <summary>
    /// Factory for creating various types of entities.
    /// </summary>
    public static class EntityFactory
    {
        /// <summary>
        /// Creates a button entity with the specified label and position.
        /// </summary>
        /// <param name="world">The world to create the entity in.</param>
        /// <param name="label">The label for the button.</param>
        /// <param name="position">The position of the button in the world.</param>
        /// <returns>The created button entity.</returns>
        public static Entity CreateButton(World world, string label, Pose position)
        {
            var entity = world.CreateEntity();
            entity.Set(new ButtonComponent { Label = label });
            entity.Set(new PositionComponent { Value = position });
            return entity;
        }


        /// <summary>
        /// Creates a text window entity with the specified text and position.
        /// </summary>
        /// <param name="world">The world to create the entity in.</param>
        /// <param name="text">The text content for the text window.</param>
        /// <param name="position">The position of the text window in the world.</param>
        /// <returns>The created text window entity.</returns>
        public static Entity CreateTextWindow(World world, string text, Pose position)
        {
            var entity = world.CreateEntity();
            entity.Set(new TextContentsComponent { TextContents = text });
            entity.Set(new PositionComponent { Value = position });
            return entity;
        }
    }
}
