using System;
using UBIK.Data;
using UBIKOIDCProcessorExtended.SystemDefinitions;

namespace UBIKOIDCProcessorExtended.Providers
{
    public class SystemDefinitionsProvider : SystemDefinitionProviderBase
    {
        public override Guid ModuleID => Settings.MODULE_ID;

        private static SystemDefinitionsProvider instance = null;

        public static SystemDefinitionsProvider Instance
        {
            get
            {
                return instance ?? (instance = new SystemDefinitionsProvider());
            }
        }

        private SystemDefinitionsProvider() :
            base(
                new SSOSystemDefinitions_V440())
        { }
    }
}
