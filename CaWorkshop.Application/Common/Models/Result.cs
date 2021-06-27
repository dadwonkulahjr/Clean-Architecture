using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWorkshop.Application.Common.Models
{
    public class Result
    {
        public bool Succeded { get; set; }
        public string[] Errors { get; set; }
        internal Result(bool succeded, IEnumerable<string> errors)
        {
            Succeded = succeded;
            Errors = errors.ToArray();
        }
        public static Result Success()
        {
            return new(succeded: true, Array.Empty<string>());
        }
        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(succeded: false, errors: errors);
        }
    }
}
