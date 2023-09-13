using UBIK.Interface;
using UBIK.Kernel;

namespace UBIKOIDCProcessorExtended.Model
{
    public class SsoLogin : Login
    {
        public static new MetaProxy SystemMetaClass(UBIKEnvironment environment) => environment != null ? environment.UBIKDataFactory().MetaClass(Settings.USER_META_CLASS) as MetaProxy : null;
    }
}
