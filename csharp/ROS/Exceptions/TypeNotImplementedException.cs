using System;

namespace ROS.Exceptions
{
    public class TypeNotImplementedException : Exception
    {
        public TypeNotImplementedException(string s) : base(s)
        {
        }
    }
}