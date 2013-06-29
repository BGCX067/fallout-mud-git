namespace Mud.Core
{
    public abstract class MultiThreadObject
    {
        protected readonly object LockVar = new object();
    }
}