using System;

namespace Groop.Website.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class NoInputAttribute : Attribute
    {
		
    }
}