using System;

namespace RecruitmentProcessApi.Exceptions
{
    public class DuplicateOrderIdException : Exception
    {
        public DuplicateOrderIdException(string message =  null)
            : base(message)
        { }
    }
}
