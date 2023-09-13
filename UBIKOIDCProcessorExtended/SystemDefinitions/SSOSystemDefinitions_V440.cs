using System;
using UBIK.Data;
using UBIK.Kernel;
using UBIKOIDCProcessorExtended.Model;

namespace UBIKOIDCProcessorExtended.SystemDefinitions
{
    public class SSOSystemDefinitions_V440 : ISystemDefinitions
    {
        public Version Version => new Version(4, 4, 0, 1);

        public void DefineDefaultSystemStrings(UBIKEnvironment environment)
        {
            
        }

        public UBIKClassList<MetaClass> DefineSystemClassifications(UBIKEnvironment environment)
        {
            return new UBIKClassList<MetaClass>();
        }

        public UBIKClassList<MetaClass> DefineSystemMetaClasses(UBIKEnvironment environment)
        {
            return new UBIKClassList<MetaClass>() { SsoLogin.SystemMetaClass(environment) };
        }

        public UBIKClassList<MetaProperty> DefineSystemMetaProperties(UBIKEnvironment environment)
        {
            return new UBIKClassList<MetaProperty>();
        }

        public UBIKClassList<SelectiveList> DefineSystemSelectiveLists(UBIKEnvironment environment)
        {
            return new UBIKClassList<SelectiveList>();
        }

        public void InitializeSystemContent(UBIKEnvironment environment)
        {
            
        }

        public string SystemRuntypeName(MetaClass metaClass)
        {
            if (metaClass != null)
            {
                if (metaClass.UID.Equals(Settings.USER_META_CLASS))
                    return typeof(SsoLogin).FullName;
            }
            return null;
        }

        public void UpdateSystemContent(UBIKEnvironment environment)
        {
            
        }
    }
}
