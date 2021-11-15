using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Models
{
    /// <summary>
    /// Cevap class'ı
    /// </summary>
    public class Answers
    {
        /// <summary>
        /// Cevap
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Tarih cevabı.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// String cevaplar için
        /// </summary>
        /// <param name="description"></param>
        public Answers(string description)
        {
            this.Description = description;
        }
        /// <summary>
        /// DateTime cevaplar için
        /// </summary>
        /// <param name="date"></param>
        public Answers(DateTime date)
        {
            this.Date = date;
        }


    }
}
