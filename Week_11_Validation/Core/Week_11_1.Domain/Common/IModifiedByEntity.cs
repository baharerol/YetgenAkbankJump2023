using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_11_1.Domain.Common
{
    public interface IModifiedByEntity
    {
        DateTimeOffset? ModifiedOn { get; set; }
    }
}
