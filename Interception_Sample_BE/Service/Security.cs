using System.Diagnostics;

namespace Interception_Sample_BE
{
    public class Security
    {
        public bool CheckAuthorization(string userName, string role)
        {
            return true;
        }

    }
}
