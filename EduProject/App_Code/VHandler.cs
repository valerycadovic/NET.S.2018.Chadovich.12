using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace EduProject
{
    public class VHandler : IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable => false; 

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sb = new StringBuilder(32);

            foreach (string index in context.Request.Headers.Keys)
            {
                sb.Append($"{index}: ");
                sb.Append(context.Request.Headers[index]);
                sb.Append("<br/>");
            }

            sb.Append("<br/>");
            sb.Append("<h2>Content</h2>");

            using (StreamReader sr = new StreamReader(context.Request.PhysicalApplicationPath + context.Request.FilePath))
            {
                sb.Append(sr.ReadToEnd());
            }
            context.Response.Write(sb.ToString());
        }
        
        #endregion
    }
}
