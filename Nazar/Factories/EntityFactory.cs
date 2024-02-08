using DefaultEcs;
using Nazar.Components;

namespace Nazar.Factories
{
    public static class EntityFactory
    {
        public static Entity CreateButton(World world, string label, Pose position)
        {
            var entity = world.CreateEntity();
            entity.Set(new ButtonComponent { Label = label });
            entity.Set(new PositionComponent { Value = position });
            return entity;
        }

        public static Entity CreateTextWindow(World world, string text, Pose position)
        {
            var entity = world.CreateEntity();
            entity.Set(new TextContentsComponent { TextContents = text });
            entity.Set(new PositionComponent { Value = position });
            return entity;
        }
    }
}
