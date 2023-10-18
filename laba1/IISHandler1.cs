using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace lab1
{
    public class IISHandler1 : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        private static int result = 0;
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //разместите здесь вашу реализацию обработчика.
            if (context.Session["stackSession"] == null)
            {
                context.Session["stackSession"] = new Stack<int>();
            }
            Stack<int> stack = context.Session["stackSession"] as Stack<int>;
            string requestType = context.Request.RequestType;
            switch (requestType)
            {
                case "GET":
                    context.Response.ContentType = "application/json";
                    if (stack.Count == 0)
                    {
                        context.Response.Write("{\"result\": " + result + "}");
                    }
                    else
                    {
                        context.Response.Write("{\"result\": " + (result + stack.Peek()) + "}");
                    }
                    break;
                case "POST":
                    result = Convert.ToInt32(context.Request.QueryString["result"]);
                    break;
                case "PUT":
                    int add = Convert.ToInt32(context.Request.QueryString["add"]);
                    stack.Push(add);
                    break;
                case "DELETE":
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                    break;
                default:
                    context.Response.StatusCode = 405;
                    context.Response.End();
                    break;
            }
            
        }

        #endregion
    }
}
