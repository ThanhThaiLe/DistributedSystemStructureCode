using System.Reflection;

namespace DistributedSystem.Presentation
{
    public class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
