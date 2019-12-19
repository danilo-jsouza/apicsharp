using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class BasicException : Exception
    {
        public int ERROR_CODE;
        public int ERROR_NUMBER = 0;
        public Exception ex;

        public BasicException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message)
        {
            ERROR_NUMBER = errorNumber;

        }
        public BasicException(string message, int errorNumber = 0, bool isDefaultMessage = false, Exception ex = null) : base(message)
        {
            ERROR_NUMBER = errorNumber;
            this.ex = ex;
        }

    }


    public class NotFoundException : BasicException
    {
        public NotFoundException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 404;

        }

    }

    public class BadRequestException : BasicException
    {
        public IList<string> Messages { get; set; }
        public BadRequestException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 400;

        }
        public BadRequestException(string message, Exception ex, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage, ex)
        {
            Console.Write(ex.StackTrace);
            ERROR_CODE = 400;

        }
        public BadRequestException(IList<string> messages, int errorNumber = 0, bool isDefaultMessage = false) : base(string.Join("<br/>", messages), errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 400;
            Messages = messages;
        }

        public BadRequestException(IList<string> messages, Exception ex, int errorNumber = 0, bool isDefaultMessage = false) : base(string.Join("<br/>", messages), errorNumber, isDefaultMessage, ex)
        {
            Console.Write(ex.StackTrace);
            ERROR_CODE = 400;
            Messages = messages;
        }
    }
    public class ConflictException : BasicException
    {
        public ConflictException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 409;

        }
    }
    public class NotAcceptableException : BasicException
    {
        public NotAcceptableException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 406;

        }
    }

    public class NotAuthorizedException : BasicException
    {
        public NotAuthorizedException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 401;

        }
    }

    public class ForbiddenException : BasicException
    {
        public ForbiddenException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 403;

        }
    }

    public class RequestTimeoutException : BasicException
    {
        public RequestTimeoutException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 408;

        }
    }

    public class UnsupportedMediaTypeException : BasicException
    {
        public UnsupportedMediaTypeException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 415;

        }
    }

    public class InternalServerError : Exception
    {
        public InternalServerError(string message) : base(message) { }
        public InternalServerError(string message, Exception ex) : base(message, ex) { }
    }

    public class GatewayTimeoutException : BasicException
    {
        public GatewayTimeoutException(string message, int errorNumber = 0, bool isDefaultMessage = false) : base(message, errorNumber, isDefaultMessage)
        {
            ERROR_CODE = 504;

        }
    }
}
