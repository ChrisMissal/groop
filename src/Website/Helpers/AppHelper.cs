using System;
using System.Web;

namespace Groop.Website.Helpers
{
    /// <summary>
    /// Provide methods that help you wade through common activities
    /// </summary>
    public static class AppHelper
    {
        #region Public Static Methods

        /// <summary>
        /// Builds an Image URL
        /// </summary>
        /// <param name="imageFile">The file name of the image</param>
        public static string ImageUrl(string imageFile)
        {
            string result = string.Format("{0}/{1}", ImageRoot, imageFile);
            return result;
        }

        /// <summary>
        /// Builds a CSS URL
        /// </summary>
        /// <param name="cssFile">The name of the CSS file</param>
        public static string CssUrl(string cssFile)
        {
            string result = string.Format("{0}/{1}", CssRoot, cssFile);
            return result;
        }

        /// <summary>
        /// Builds a JavaScript URL
        /// </summary>
        /// <param name="jsFile">The name of the JS file</param>
        public static string JsUrl(string jsFile)
        {
            string result = string.Format("{0}/{1}", JsRoot, jsFile);
            return result;
        }

        /// <summary>
        /// Builds a Swf URL
        /// </summary>
        /// <param name="swfFile">The name of the JS file</param>
        public static string SwfUrl(string swfFile)
        {
            string result = string.Format("{0}/{1}", SwfRoot, swfFile);
            return result;
        }

        #endregion

        #region Public Static Properties

        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <value>The root.</value>
        public static string Root
        {
            get
            {
                const string contentVirtualRoot = "~/";
                string rootPath = VirtualPathUtility.ToAbsolute(contentVirtualRoot);

                return rootPath.TrimEnd('/');
            }
        }

        /// <summary>
        /// Returns an absolute reference to the Content directory
        /// </summary>
        public static string ContentRoot
        {
            get { return string.Format("{0}/{1}", Root, "Content"); }
        }

        /// <summary>
        /// Returns an absolute reference to the Images directory
        /// </summary>
        public static string ImageRoot
        {
            get { return string.Format("{0}/{1}", ContentRoot, "images"); }
        }

        /// <summary>
        /// Returns an absolute reference to the CSS directory
        /// </summary>
        public static string CssRoot
        {
            get { return string.Format("{0}/{1}", ContentRoot, "css"); }
        }

        /// <summary>
        /// Returns an absolute reference to the javascript directory
        /// </summary>
        public static string JsRoot
        {
            get { return string.Format("{0}/{1}", ContentRoot, "js"); }
        }

        /// <summary>
        /// Returns an absolute reference to the swf directory
        /// </summary>
        public static string SwfRoot
        {
            get { return string.Format("{0}/{1}", ContentRoot, "swf"); }
        }

        #endregion
    }
}