namespace LiveTemplateMacros
{
    using System.Collections.Generic;
    using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
    using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

    //// http://chrislaco.com/articles/writing-resharper-45x-macros/

    [Macro("LowerCase", ShortDescription = "Convert {#0:variable} to all lowercase",
        LongDescription = "Used for BDD Descriptions. Converts the content of the variable to all lowercase.")]
    public class LowerCaseMacro : IMacro
    {
        public string EvaluateQuickResult(IHotspotContext context, IList<string> arguments)
        {
            if (arguments.Count != 1)
            {
                return "<wrong number of arguments>";
            }

            return arguments[0].ToLowerInvariant();
        }

        public ParameterInfo[] Parameters
        {
            get { return new[] { new ParameterInfo(ParameterType.VariableReference) }; }
        }

        public string GetPlaceholder()
        {
            return "<LowerCaseMacro>";
        }

        public bool HandleExpansion(IHotspotContext context, IList<string> arguments)
        {
            return false;
        }

        public HotspotItems GetLookupItems(IHotspotContext context, IList<string> arguments)
        {
            return null;
        }
    }
}