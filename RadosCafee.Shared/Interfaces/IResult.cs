using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Shared.Interfaces
{
    public interface IResult<T>
    {
        List<string> Messages { get; set; }
        bool Succeeded { get; set; }
        T Data { get; set; }
        Exception Exception { get; set; }
        int Code { get; set; }
        List<ValidationResult> ValidationErrors { get; set; }
    }
}
