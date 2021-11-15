using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Models
{
    /// <summary>
    /// Seçenek class'ı
    /// </summary>
    public class Options
    {

        /// <summary>
        /// Seçeneğin açıklaması.
        /// </summary>
        public string Description { get; private set; }



        public Options(string description)
        {
            Description = description;

        }

    }
}
