using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Application.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException()
        {
        }

        public DuplicateException(string message) : base(message)
        {
        }
    }
}
