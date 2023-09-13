using System;

namespace UBIKOIDCProcessorExtended
{
    internal static class Settings
    {
        internal static Guid MODULE_ID = new Guid("79A140DD-663B-4A3A-8657-99BF280B613D");
        internal static Guid USER_META_CLASS = new Guid("d55f232e-6fd8-4b5b-9d38-74157941236a");
        internal static string KEY_MAIL = @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        internal static string KEY_NAME = @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname";
        internal static string KEY_SURNAME = @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname";
        internal static string KEY_MAIL_BACKUP = @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
    }
}
