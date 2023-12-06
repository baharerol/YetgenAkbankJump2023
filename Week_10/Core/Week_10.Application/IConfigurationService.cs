using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10_2.Application
{
    public interface IConfigurationService
    {
        string GetValue(string key);
    }
}