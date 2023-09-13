using System.Reflection;
using UBIK.Kernel;
using UBIK.Service.DTO.V220;
using UBIK.SSO.OIDCProcessor;

namespace UBIKOIDCProcessorExtended
{
    public class OIDCProcessorExtExt : OIDCProcessorExt
    {
        public OIDCProcessorExtExt(UBIKEnvironment environment, string token, string jwks) : base(environment, token, jwks)
        {
        }

        /*public override bool IsValid()
        {
            foreach (var kv in base.Assertions())
            {
                UBIKKernel.LogCustomizing(System.Reflection.MethodBase.GetCurrentMethod(),
                $"Key: {kv.Key} - Value: {kv.Value.ToString()}");
            }
            
            return base.IsValid();
        }*/

        protected override Login CreateLogin(string loginName, string domain, OSTypes osType)
        {
            Login login = null;
            if (!string.IsNullOrEmpty(loginName))
            {
                MetaClass metaClass = Environment.UBIKDataFactory().MetaClass(Settings.USER_META_CLASS);
                if (metaClass != null)
                {
                    login = metaClass.CreateNewInstance() as Login;
                    if (login != null)
                    {
                        login.LOGINNAME = loginName;
                        if (login is DomainLogin && !string.IsNullOrEmpty(domain))
                        {
                            ((DomainLogin)login).DOMAINNAME = domain;
                        }

                        if (osType != 0)
                        {
                            login.TrySetValue("OS_TYPE", (int)osType);
                        }

                        if (Assertions().ContainsKey(Settings.KEY_MAIL) && !string.IsNullOrEmpty(Assertions()[Settings.KEY_MAIL] as string))
                        {
                            login.Name = Assertions()[Settings.KEY_MAIL] as string;
                            UBIKKernel.LogCustomizing(MethodBase.GetCurrentMethod(),
                                $"Login name for {login.ID} was set to {login.Name} -> Key: {Settings.KEY_MAIL}");
                        }
                        else if (Assertions().ContainsKey(Settings.KEY_MAIL_BACKUP) && !string.IsNullOrEmpty(Assertions()[Settings.KEY_MAIL_BACKUP] as string))
                        {
                            login.Name = Assertions()[Settings.KEY_MAIL_BACKUP] as string;
                            UBIKKernel.LogCustomizing(MethodBase.GetCurrentMethod(),
                                $"Login name for {login.ID} was set to {login.Name} -> Key: {Settings.KEY_MAIL_BACKUP}");
                        }
                        else
                        {
                            UBIKKernel.LogError(1288,
                                login,
                                MethodBase.GetCurrentMethod(),
                                $"Login name for {login.ID} was not set!");
                        }

                        if (Assertions().ContainsKey(Settings.KEY_NAME) && Assertions().ContainsKey(Settings.KEY_SURNAME) && !string.IsNullOrEmpty(Assertions()[Settings.KEY_NAME] as string) && !string.IsNullOrEmpty(Assertions()[Settings.KEY_SURNAME] as string))
                        {
                            login.Description = string.Format("{0} {1}", Assertions()[Settings.KEY_NAME], Assertions()[Settings.KEY_SURNAME]);
                            UBIKKernel.LogCustomizing(MethodBase.GetCurrentMethod(),
                                $"Login Description for {login.ID} was set to {login.Description} -> Key: {Settings.KEY_NAME} and {Settings.KEY_SURNAME}");
                        }
                        else if (Assertions().ContainsKey(Settings.KEY_MAIL_BACKUP) && !string.IsNullOrEmpty(Assertions()[Settings.KEY_MAIL_BACKUP] as string))
                        {
                            login.Description = Assertions()[Settings.KEY_MAIL_BACKUP] as string;
                            UBIKKernel.LogCustomizing(MethodBase.GetCurrentMethod(),
                                $"Login Description for {login.ID} was set to {login.Description} -> Key: {Settings.KEY_MAIL_BACKUP}");
                        }
                        else
                        {
                            UBIKKernel.LogError(1288,
                                login,
                                MethodBase.GetCurrentMethod(),
                                $"Login Description for {login.ID} was not set!");
                        }
                    }
                }
            }
            return login;
        }
    }
}
