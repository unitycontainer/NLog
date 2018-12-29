using NLog;
using System;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;

namespace Unity.NLog
{
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
            Func<Type, string> method = GetName ?? _defaultGetName;
            var DeclaringType = context.DeclaringType;

            return (ref BuilderContext c) => LogManager.GetLogger(method(DeclaringType)); 
        }
    }
}
