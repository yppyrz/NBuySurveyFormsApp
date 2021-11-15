using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Services
{
    public interface Check<T> where T:class
    {
        List<T> Check(T t);
    }
}
