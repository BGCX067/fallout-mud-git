namespace Mud.Core
{
    using Mud.Abstractions.Communication;
    using Mud.Communication.Tcp;

    public static class ApplicationServices
    {
        private static IConnectionManager connectionManager;

        public static IConnectionManager ConnectionManager
        {
            get
            {
                return connectionManager ?? (connectionManager = new TcpConnectionManager());
            }
        }
    }
}
