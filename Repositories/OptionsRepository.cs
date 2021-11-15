using NBuySurveyFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Repositories
{
    /// <summary>
    /// Seçeneklerin tutulduğu class.
    /// </summary>
    public class OptionsRepository : IRepository<Options>
    {
        private HashSet<Options> _options = new HashSet<Options>();
        public List<Options> GetData()
        {
            var option1 = new Options(description: "Apple");
            _options.Add(option1);
            var option2 = new Options(description: "Samsung");
            _options.Add(option2);
            var option3 = new Options(description: "Nokia");
            _options.Add(option3);

            return _options.ToList();
        }

    }
}
