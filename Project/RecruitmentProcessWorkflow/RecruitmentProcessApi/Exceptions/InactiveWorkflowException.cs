using System;

namespace RecruitmentProcessApi.Exceptions
{
    public class InactiveWorkflowException : Exception
    {
        public InactiveWorkflowException(string message)
            : base(message)
        {}
    }
}
