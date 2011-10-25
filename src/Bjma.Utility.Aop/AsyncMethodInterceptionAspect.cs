namespace Bjma.Utility.Aop
{
    using System;
    using System.Threading;
    using PostSharp.Aspects;

    /// <summary>
    /// Responsible for providing an abstract base type for 
    /// the provision of functionality to run behavior 
    /// asynchronously from within an aspect.
    /// </summary>
    [Serializable]
    public abstract class AsyncMethodInterceptionAspect : MethodInterceptionAspect
    {       
        /// <summary>
        /// Must be public for PostSharp to see (making protected results in a compiler warning).
        /// </summary>
        public virtual void PerformActionAsynchronously(Action actionToPerform)
        {
            if (actionToPerform == null) { throw new ArgumentNullException("actionToPerform");}

            ThreadPool.QueueUserWorkItem(o => actionToPerform.Invoke()); //faster than the task factory by a few milliseconds
        }
    }
}
