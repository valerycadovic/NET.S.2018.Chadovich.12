using System;
using System.Diagnostics;
using System.Web;

namespace EduProject
{
    public class TimerRequestModule : IHttpModule
    {
        private Stopwatch timer;

        #region IHttpModule Members

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += this.OnBeginRequest;
            context.EndRequest += this.OnEndRequest;
        }

        #endregion

        private void OnBeginRequest(object sender, EventArgs ea)
        {
            timer = Stopwatch.StartNew();
        }

        private void OnEndRequest(object sender, EventArgs ea)
        {
            var context = HttpContext.Current;
            context.Response.Write($"<div style='color:red;'>Время обработки запроса: " +
                                   $"{((float)timer.ElapsedTicks) / Stopwatch.Frequency:F5} секунд</div>");
        }
    }
}
