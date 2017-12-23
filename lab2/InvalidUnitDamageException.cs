using System;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace lab2
{
    public class InvalidEntityException<T> : Exception where T : Entity
    {
        public InvalidEntityException(T obj)
        {
            //TODO
        }
    }
}