using NLog;
using System;
using System.Security;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;
using Unity.Resolution;

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
            Type declaringType = context.DeclaringType;

            return (ref BuilderContext c) => LogManager.GetLogger(method(declaringType)); 
        }
    }
}
