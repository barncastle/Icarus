using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Icarus.Logic.Offsets
{
    internal static class OffsetStore
    {
        private static readonly Dictionary<int, IOffset> Offsets;

        static OffsetStore()
        {
            Offsets = new Dictionary<int, IOffset>(0x40);

            var assembly = Assembly.GetCallingAssembly();
            foreach (var ti in assembly.DefinedTypes)
            {
                if (ti.ImplementedInterfaces.Contains(typeof(IOffset)))
                {
                    var instance = (IOffset)assembly.CreateInstance(ti.FullName);
                    Offsets[instance.Build] = instance;
                }
            }
        }

        public static bool TryGetOffset(int build, out IOffset instance)
        {
            return Offsets.TryGetValue(build, out instance);
        }
    }
}