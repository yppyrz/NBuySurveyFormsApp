using NBuySurveyFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Services
{
    public class CheckQuestion : Check<Question>
    {
        private HashSet<Question> _question = new HashSet<Question>();
        public CheckQuestion(Question question)
        {
            Check(question);
        }
        public List<Question> Check(Question question)
        {
            var questionType = question.QuestionType.ToString();

            var optionsList = question.Options.ToList();
            var optionsListCount = optionsList.Count;

            // Kısa cevap soru tipinde 1 seçenek olabilir.
            if (questionType == "Short")
            {

                if (optionsListCount == 1)
                {
                    foreach (var option in optionsList)
                    {
                        if (option.Description.Length > 0)
                        {
                            _question.Add(question);
                        }
                        else
                        {
                            throw new Exception("Seçenek boş olamaz");
                        }
                    }

                }
                else
                {
                    throw new Exception("Kısa soru tipinin seçeneği birden fazla olamaz.");

                }

            }

            // Uzun cevap soru tipinde 1 seçenek olabilir.
            else if (questionType == "Long")
            {
                if (optionsListCount == 1)
                {
                    foreach (var option in optionsList)
                    {
                        if (option.Description.Length > 0)
                        {
                            _question.Add(question);
                        }
                        else
                        {
                            throw new Exception("Seçenek boş olamaz");
                        }
                    }

                }
                else
                {
                    throw new Exception("Uzun soru tipinin seçeneği birden fazla olamaz.");

                }
            }

            // EvetHayır soru tipinin Evet ve Hayır olmak üzere 2 adet seçeneği olmalı
            else if (questionType == "TrueFalse")
            {
                if (optionsListCount <= 2)
                {
                    var trueOptions = optionsList.Find(x => x.Description == "Evet");
                    var falseOptions = optionsList.Find(x => x.Description == "Hayır");
                    if (trueOptions != null || falseOptions != null)
                    {
                        _question.Add(question);

                    }
                    else
                    {
                        throw new Exception("EvetHayır soru tipinin 2 adet seçeneği olmalı.");

                    }

                }
                else
                {
                    throw new Exception("EvetHayır soru tipinin 2 adet seçeneği olmalı.");
                }
            }
            else if (questionType == "MultipleChoice")
            {
                if (optionsListCount > 0 && optionsListCount <= 4)
                {
                    foreach (var option in optionsList)
                    {
                        if (option.Description.Length > 0)
                        {
                            _question.Add(question);
                        }
                        else
                        {
                            throw new Exception("Seçenek boş olamaz");
                        }
                    }

                }
                else
                {
                    throw new Exception("Çoktan seçmeli soru tipinin seçenekleri en az 1 en fazla 4 adet olabilir.");

                }
            }
            else if (questionType == "CheckBox")
            {
                if (optionsListCount > 0 && optionsListCount <= 5)
                {
                    foreach (var option in optionsList)
                    {
                        if (option.Description.Length > 0)
                        {
                            _question.Add(question);
                        }
                        else
                        {
                            throw new Exception("Seçenek boş olamaz");
                        }
                    }

                }
                else
                {
                    throw new Exception("Onay kutusu soru tipinin seçenekleri en az 1 en fazla 5 olabilir.");

                }
            }
            else if (questionType == "Date")
            {
                if (optionsListCount == 1)
                {
                                        foreach (var option in optionsList)
                    {
                        if (option.Description.Length > 0)
                        {
                            _question.Add(question);
                        }
                        else
                        {
                            throw new Exception("Seçenek boş olamaz");
                        }
                    }

                }
                else
                {
                    throw new Exception("Kısa soru tipinin seçeneği birden fazla olamaz.");

                }
            }
            return _question.ToList();
        }


    }
}
