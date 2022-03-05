using CountryStateApplication.Debugging;

namespace CountryStateApplication
{
    public class CountryStateApplicationConsts
    {
        public const string LocalizationSourceName = "CountryStateApplication";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "70f9b0f811f746818bc5f45930fbc780";
    }
}
