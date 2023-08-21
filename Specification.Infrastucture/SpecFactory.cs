using System.Collections.Concurrent;

namespace Specification.Infrastucture
{
    public static class SpecFactory
    {
        private static readonly ConcurrentDictionary<Type, SpecBase>
            _registeredSpecs = new ConcurrentDictionary<Type, SpecBase>();

        public static T Default<T>() where T : SpecBase, new()
        {
            return (T)_registeredSpecs.GetOrAdd(typeof(T), _ => new T());
        }
    }
}