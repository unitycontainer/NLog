using NLog;
using System;
using System.Runtime.CompilerServices;
using System.Security;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;

namespace Unity.NLog
{
    [SecuritySafeCritical]
    public class NLogExtension : UnityContainerExtension
    {
        private static readonly Func<Type, string> _defaultGetName = (t) => t.FullName;

        public Func<Type, string> GetName { get; set; }

        protected override void Initialize()
        {
            Context.Policies.Set(typeof(ILogger), null, typeof(ResolveDelegateFactory), (ResolveDelegateFactory)GetResolver);
        }

        public ResolveDelegate<BuilderContext> GetResolver(ref BuilderContext context)
        {
            var method = GetName ?? _defaultGetName;
            Type declaringType;

            unsafe
            {
                var parenContext = Unsafe.AsRef<BuilderContext>(context.Parent.ToPointer());
                declaringType = parenContext.RegistrationType;
            }

            return (ref BuilderContext c) => LogManager.GetLogger(method(declaringType)); 
        }
    }
}
