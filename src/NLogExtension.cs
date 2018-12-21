using NLog;
using System;
using Unity.Builder;
using Unity.Extension;
using Unity.Policy;

namespace Unity.NLog
{
    public class NLogExtension : UnityContainerExtension, IBuildPlanPolicy
    {
        private static readonly Func<Type, string> _defaultGetName = (t) => t.FullName;

        public Func<Type, string> GetName { get; set; }

        protected override void Initialize()
        {
            Context.Policies.Set(typeof(ILogger), null, typeof(IBuildPlanPolicy), this);
        }

        public void BuildUp(ref BuilderContext context)
        {
            Func<Type, string> method = GetName ?? _defaultGetName;
            context.Existing = LogManager.GetLogger(method(context.DeclaringType));
            context.BuildComplete = true;
        }
    }
}
