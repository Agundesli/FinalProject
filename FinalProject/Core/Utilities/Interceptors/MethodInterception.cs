using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation)
        {
            
        }
        protected virtual void OnAfter(IInvocation invocation)
        {

        }
        protected virtual void OnException(IInvocation invocation, System.Exception e)
        {

        }
        protected virtual void OnSucces(IInvocation invocation)
        {

        }
        public override void Intercept(IInvocation invocation)
        {
            var isSucces = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch(Exception e)
            {
                isSucces = false;
                OnException(invocation,e);
                throw;
            }
            finally
            {
                if (isSucces)
                {
                    OnSucces(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
