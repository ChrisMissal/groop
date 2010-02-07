using System;
using System.IO;
using System.Web;
using Groop.Core;

namespace Groop.Website
{
    public class ApplicationPathResolver : IPathResolver
    {
        public virtual string Resolve(string path)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(path);
            }

            return path;
        }
    }
}