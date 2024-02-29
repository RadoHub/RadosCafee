using RadosCafee.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Shared.Concrete
{
    public class Result<T> : IResult<T>
    {
        public List<string> Messages { get ; set ; } = new List<string>();
        public bool Succeeded { get ; set ; }
        public T Data { get ; set ; }
        public Exception Exception { get ; set ; }
        public int Code { get ; set ; }
        public List<ValidationResult> ValidationErrors { get; set; } = new List<ValidationResult>();

        #region NonAsync Success Methods
        public static Result<T> Success( )
        {
            return new Result<T>
            {
                Succeeded = true
            };
        }
        public static Result<T> Success( string Message ) 
        {
            return new Result<T> 
            {
                Succeeded = true,
                Messages = new List<string> { Message }
            };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T> 
            {
                Succeeded = true,
                Data = data
            };
        }

        public static Result<T> Success(int code)
        {
            return new Result<T>
            {
                Succeeded = true,
                Code = code
            };
        }
        public static Result<T> Success(T data, string Message)
        {
            return new Result<T>
            {
                Succeeded = true,
                Data = data,
                Messages = new List<string> { Message }
            };
        }
        public static Result<T> Success(int code, T data)
        {
            return new Result<T>
            {
                Succeeded = true,
                Code = code,
                Data = data
            };
        }
        #endregion

        #region non async failure methods
        public static Result<T> Failure()
        {
            return new Result<T>
            {
                Succeeded = false,
            };
        }

        public static Result<T> Failure(string message)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = new List<string> { message }
            };
        }

        public static Result<T> Failure(List<string> messages)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = messages
            };
        }

        public static Result<T> Failure(int code)
        {
            return new Result<T>
            {
                Succeeded = false,
                Code = code
            };
        }

        public static Result<T> Failure(T data)
        {
            return new Result<T>
            {
                Succeeded = false,
                Data = data
            };
        }

        public static Result<T> Failure(T data, string message)
        {
            return new Result<T>
            {
                Succeeded = false,
                Data = data,
                Messages = new List<string> { message }
            };
        }

        public static Result<T> Failure(T data, List<string> messages)
        {
            return new Result<T>
            {
                Succeeded = false,
                Data = data,
                Messages = messages
            };
        }

        public static Result<T> Failure(Exception exception)
        {
            return new Result<T>
            {
                Succeeded = false,
                Exception = exception
            };
        }
        #endregion


        /// <summary>
        /// Async Methodlar altta yazildi
        /// </summary>
        /// <returns></returns>

        #region async success methods
        public static Task<Result<T>> SuccessAsync()
        {
            return  Task.FromResult(Success());
        }
        public static Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(int code)
        {
            return Task.FromResult(Success(code));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        #endregion

        #region async failure methofs
        public static Task<Result<T>> FailureAsync() { return Task.FromResult(Failure()); }

        public static Task<Result<T>> FailureAsync(string message)
        {
            return Task.FromResult(Failure(message));
        }
        public static Task<Result<T>> FailureAsync(List<string> messages) { return Task.FromResult(Failure(messages)); }

        public static Task<Result<T>> FailureAsync(T data) {  return Task.FromResult(Failure(data));}

        public static Task<Result<T>> FailureAsync(T data, string message) { return Task.FromResult(Failure(data, message)); }

        public static Task<Result<T>> FailureAsync(T data, List<string> messages) { return Task.FromResult(Failure(data, messages)); }

        public static Task<Result<T>> FailureAsync(Exception exception) { return Task.FromResult(Failure(exception)); }

        #endregion 
    }
}
