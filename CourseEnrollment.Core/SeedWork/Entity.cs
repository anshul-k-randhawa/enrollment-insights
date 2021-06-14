
using System;

namespace CourseEnrollment.Core.SeedWork
{
    public abstract class Entity
    {
        public string id { get; } = Guid.NewGuid().ToString();
    }
}
