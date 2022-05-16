using System.Runtime.CompilerServices;

namespace EAppBase.Libs
{
    public class DebugUtils
    {

        public static string __FUNCTION__([CallerMemberName]string caller="")
        {
            return caller;
        }
    }
}
