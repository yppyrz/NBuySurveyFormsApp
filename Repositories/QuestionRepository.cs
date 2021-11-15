using NBuySurveyFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private HashSet<Question> _questions = new HashSet<Question>();
        public List<Question> GetData()
        {
            var q1 = new Question(title: "Telefon Markası", type: Models.Type.MultipleChoice);
            _questions.Add(q1);
            var q2 = new Question(title: "Mouse Markası", type: Models.Type.CheckBox);
            _questions.Add(q2);

            return _questions.ToList();
        }
    }
}
