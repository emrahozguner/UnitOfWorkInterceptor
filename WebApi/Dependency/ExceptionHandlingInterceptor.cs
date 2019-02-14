using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;

namespace WebApi.Dependency
{
    public class ExceptionHandlingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.Write("Exception in : " + invocation.Method.Name + " method." + ex);
                //invocation.ReturnValue = new BaseResponse { IsSuccess = false };
            }
        }
    }
}