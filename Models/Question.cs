using NBuySurveyFormsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Models
{
    /// <summary>
    /// Soruları tutan class.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Sorunun başlığı.
        /// </summary>
        public string QuestionTitle { get; private set; }

        /// <summary>
        /// Sorunun tipi.
        /// </summary>
        public Type QuestionType { get; private set; }

        /// <summary>
        /// Sorunun seçeneklerinin listesi.
        /// </summary>
        private HashSet<Options> _options = new HashSet<Options>();
        public IReadOnlySet<Options> Options => _options;

        /// <summary>
        /// Cevapların listesi.
        /// </summary>
        private HashSet<Answers> _answers = new HashSet<Answers>();
        public IReadOnlySet<Answers> Answers => _answers;

        public Question(string title, Type type)
        {
            this.QuestionTitle = title;
            this.QuestionType = type;

        }

        /// <summary>
        /// Soruya seçenek ekleme.
        /// </summary>
        /// <param name="options"></param>
        public void AddOption(Options options)
        {
            _options.Add(options);
            var checkQuestion = new CheckQuestion(this);// Soruya seçenek eklerken, eklenen seçenekleri kontrol ediyoruz.
        }

        /// <summary>
        /// Sorudan seçenek silme.
        /// </summary>
        /// <param name="options"></param>
        public void RemoveOption(Options options)
        {
            var optionsList = _options.ToList();
            var optionsItem = optionsList.Find(x => x == options);

            // Sorudan seçenek silerken, sildiğimiz seçeneğin kontrolünü yapıyoruz.
            if (_options.Count != 0)
            {
                if (optionsItem == null)
                {
                    throw new Exception("Soruya bu seçenek eklenmemiştir.");

                }
                else
                {
                    _options.Remove(options);

                }

            }
            else
            {
                throw new Exception("Soruya hiç seçenek eklenmemiştir.");
            }
        }

        /// <summary>
        /// Soruya cevap ekleme.
        /// </summary>
        /// <param name="answer"></param>
        public void AddAnswer(Answers answer)
        {
            _answers.Add(answer);
            var checkAnswer= new CheckAnswers(this); // Soruya cevap eklerken cevapları kontrol ediyoruz.
        }

        /// <summary>
        /// Sorudan cevap silme.
        /// </summary>
        /// <param name="answer"></param>
        public void RemoveAnswer(Answers answer)
        {
            var answersList = _answers.ToList();
            var answersItem = answersList.Find(x => x == answer);
            if (_answers.Count != 0)
            {
                if (answersItem == null)
                {
                    throw new Exception("Soruya bu cevap eklenmemiştir.");

                }
                else
                {
                    _answers.Remove(answer);
                }

            }
            else
            {
                throw new Exception("Soruya hiç cevap eklenmemiştir.");
            }

        }

        /// <summary>
        /// Hiçbiri cevabı geldiğinde, cevap listesi temizlenip sadece "Hiçbiri" cevabını döndürür.
        /// </summary>
        public void NoneAnswer()
        {
            _answers.Clear();
            _answers.Add(new Answers(description:"Hiçbiri"));
        }
    }
}
