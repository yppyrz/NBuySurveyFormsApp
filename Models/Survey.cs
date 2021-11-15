using NBuySurveyFormsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Models
{
    public class Survey
    {
        /// <summary>
        /// Anket başlığı.
        /// </summary>
        public string SurveyTitle { get; private set; }

        /// <summary>
        /// Anket bilgilendirmesi.
        /// </summary>
        public string SurveyDescription { get; private set; }

        /// <summary>
        /// Ankete katılan kullanıcının bilgisi.
        /// </summary>
        public string UserInfo { get; set; }

        /// <summary>
        /// Anketi oluştururken belirlenen maksimum soru sayısı.
        /// </summary>
        public int NumberOfQuestion { get; private set; }

        /// <summary>
        /// Anketin oluşturulma tarihi.
        /// </summary>
        public DateTime SurveyDate { get; private set; }

        /// <summary>
        /// Anketin içerisindeki sorular.
        /// </summary>
        private HashSet<Question> _questions = new HashSet<Question>();
        public IReadOnlySet<Question> Questions => _questions;

        public Survey(string title, string description, int number, DateTime date)
        {
            this.SurveyTitle = title;
            this.SurveyDescription = description;
            this.NumberOfQuestion = number;
            this.SurveyDate = date;
        }

        /// <summary>
        /// Ankete soru ekleme.
        /// </summary>
        /// <param name="question"></param>
        public void AddQuestion(Question question)
        {
            // Anketteki soru sayısı, Anket soru sayısından az ise soru ekleyebiliriz.
            if (_questions.Count < NumberOfQuestion)
            {
                var checkQuestion = new CheckQuestion(question);
                var checkAnswer = new CheckAnswers(question);
                _questions.Add(question);

            }
            else
            {
                throw new Exception($"Ankette en fazla {this.NumberOfQuestion} adet soru olabilir.");
            }

        }

        /// <summary>
        /// Anketten soru silme.
        /// </summary>
        /// <param name="question"></param>
        public void DeleteQuestion(Question question)
        {
            
            var questionList = _questions.ToList();
            var questionItem = questionList.Find(x => x == question);

            // Anketten soru silerken, sildiğimiz sorunun kontrolünü yapıyoruz.
            if (_questions.Count != 0)
            {
                if (questionItem == null)
                {
                    throw new Exception("Ankete bu soru eklenmemiştir.");

                }
                else
                {
                    _questions.Remove(question);
                }

            }
            else
            {
                throw new Exception("Ankete hiç soru eklenmemiştir.");
            }


        }
                    /* Method içerisine ConsolWrite yazılması doğru olmadığı için bu kısımlar return koduna çevirilecek.*/
        public void CreateSurvey()
        {
            Console.WriteLine($"{this.SurveyTitle}\t{this.SurveyDate}\n{this.SurveyDescription}");
            var surveyQuestionList = this.Questions.ToList();
            foreach (var question in surveyQuestionList)
            {
                Console.WriteLine($"{question.QuestionTitle}");

                var surveyQuestionOptions = question.Options.ToList();
                foreach (var options in surveyQuestionOptions)
                {
                    Console.WriteLine($"\t{options.Description}");

                }
            }
        }
        /* Method içerisine ConsolWrite yazılması doğru olmadığı için bu kısımlar return koduna çevirilecek.*/
        public void ShowResult()
        {
            Console.WriteLine($"{this.SurveyTitle}\t{this.SurveyDate}\n\t\t\t{this.SurveyDescription}");
            var surveyQuestionList = this.Questions.ToList();
            foreach (var question in surveyQuestionList)
            {
                Console.WriteLine($"{question.QuestionTitle}");

                var surveyQuestionOptions = question.Options.ToList();
                var surveyQuestionAnswers = question.Answers.ToList();
                foreach (var options in surveyQuestionOptions)
                {
                    Console.WriteLine($"\t{options.Description}");

                    
                }
                foreach (var answers in surveyQuestionAnswers)
                {
                        if (answers.Description != default)
                        {
                            Console.WriteLine($"\t\t{answers.Description}");
                        }
                        else
                        {
                            Console.WriteLine($"\t\t{answers.Date.ToString()}");

                        }
                }
            }
        }

    }
}
