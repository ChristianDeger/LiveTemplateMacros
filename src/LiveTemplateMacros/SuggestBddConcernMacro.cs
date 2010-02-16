namespace LiveTemplateMacros
{
    using System.Collections.Generic;
    using System.Globalization;
    using JetBrains.DocumentModel;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
    using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

    //// http://chrislaco.com/articles/writing-resharper-45x-macros/

    [Macro("SuggestBddConcern", ShortDescription = "Suggest concern type based on the filename",
        LongDescription =
            "Suggest concern type based on the filename. Per convention the filename should end with 'Specs'. This suffix will be trimmed."
        )]
    public class SuggestBddConcernMacro : IMacro
    {
        public string EvaluateQuickResult(IHotspotContext context, IList<string> arguments)
        {
            return null;
        }

        public ParameterInfo[] Parameters
        {
            get { return new ParameterInfo[0]; }
        }

        public string GetPlaceholder()
        {
            return "<SuggestBddConcernMacro>";
        }

        public bool HandleExpansion(IHotspotContext context, IList<string> arguments)
        {
            return false;
        }

        public HotspotItems GetLookupItems(IHotspotContext context, IList<string> arguments)
        {
            return MacroUtil.SimpleEvaluateResult(Evaluate(context));
        }

        private static string Evaluate(IHotspotContext context)
        {
            string fileName = GetFileNameWithoutExtension(context);
            return fileName.EndsWith("Specs", false, CultureInfo.InvariantCulture)
                       ? fileName.Substring(0, fileName.Length - 5)
                       : "ConcernType";
        }

        private static string GetFileNameWithoutExtension(IHotspotContext context)
        {
            IProjectFile projectItem =
                DocumentManager.GetInstance(context.SessionContext.Solution)
                    .GetProjectFile(context.HotspotSession.Context.TextControl.Document);
            return projectItem != null
                       ? projectItem.Location.NameWithoutExtension
                       : string.Empty;
        }
    }
}