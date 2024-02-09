using System;

namespace DefaultEcs.Components
{
    public struct EntityIdComponent
    {
        public readonly Guid Id;

        public EntityIdComponent()
        {
            Id = Guid.NewGuid();
        }
    }
}
