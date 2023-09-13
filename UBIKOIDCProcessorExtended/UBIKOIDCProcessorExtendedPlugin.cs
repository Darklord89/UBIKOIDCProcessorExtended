using System.ComponentModel.Composition;
using UBIK.Data;
using UBIK.Injection;
using UBIK.Kernel;

namespace UBIKOIDCProcessorExtended
{
    [Export(typeof(IUbikPlugin))]
    [ExportMetadata("ID", "79A140DD-663B-4A3A-8657-99BF280B613D")]
    [ExportMetadata("Type", typeof(UBIKOIDCProcessorExtendedPlugin))]
    [ExportMetadata("Name", "UBIKOIDCProcessorExtendedPlugin")]
    [ExportMetadata("Description", "OIDC extension for oreginal OIDC Plugin")]
    [ExportMetadata("Version", 3)]
    [ExportMetadata("Company", "Siemens s.r.o.")]
    [ExportMetadata("Copyright", "2023, Siemens s.r.o.")]
    [ExportMetadata("MinimumKernelVersion", "4.4.0.0")]
    public class UBIKOIDCProcessorExtendedPlugin :
        ISessionAwareUbikModule,
        IUbikModule,
        IUbikPlugin
    {
        public ISystemDefinitionProvider SystemDefinitionsProvider => Providers.SystemDefinitionsProvider.Instance;

        public UBIKEnvironment Environment {  get; private set; }

        public void Initialize(UBIKEnvironment environment)
        {
            Environment = environment;
        }

        public bool Initialized()
        {
            return Environment != null;
        }

        public void Terminate(UBIKEnvironment environment)
        {
            Terminate();
        }

        public void Terminate()
        {
            Environment = null;
        }
    }
}
