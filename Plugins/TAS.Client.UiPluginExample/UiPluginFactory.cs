using System;
using System.ComponentModel.Composition;
using TAS.Client.Common.Plugin;

namespace TAS.Client.UiPluginExample
{
    [Export(typeof(IUiPluginFactory))]
    public class UiPluginFactory: IUiPluginFactory
    {
        public object[] Create(IUiPluginContext context)
        {
            return new object[] { new UiPlugin(context) };
        }

        public Type Type { get; } = typeof(UiPlugin);
    }
}
