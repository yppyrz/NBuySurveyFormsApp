using NBuySurveyFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Services
{
    public class CheckAnswers : Check<Question>
    {
        private HashSet<Question> _question = new HashSet<Question>();
        public CheckAnswers(Question question)
        {
            Check(question);
        }
        public List<Question> Check(Question question)
        {
            var questionType = question.QuestionType.ToString();

            var answersList = question.Answers.ToList();
            var answersListCount = answersList.Count;

            // Kısa cevap soru tipinde 1 cevap olabilir.
            if (questionType == "Short")
            {

                if (answersListCount == 1)
                {
                    answersList.ForEach(a =>
                    {
                        if (a.Description.Length > 0)
                        {
                            if (a.Description.Length > 30)
                            {
                                throw new Exception("Kısa soru tipinin cevabı 30 karakteri aşamaz.");
                            }
                            else
                            {
                                _question.Add(question);

                            }
                        }
                        else
                        {
                            throw new Exception("Cevap boş olamaz.");
                        }

                    });
                }
                else
                {
                    throw new Exception("Kısa soru tipinin cevabı birden fazla olamaz.");

                }

            }

            // Uzun cevap soru tipinde 1 cevabı olabilir.
            else if (questionType == "Long")
            {
                if (answersListCount == 1)
                {
                    answersList.ForEach(a =>
                    {
                        if (a.Description.Length > 0)
                        {
                            if (a.Description.Length > 200)
                            {
                                throw new Exception("Kısa soru tipinin cevabı 200 karakteri aşamaz.");
                            }
                            else
                            {
                                _question.Add(question);

                            }
                        }
                        else
                        {
                            throw new Exception("Cevap boş olamaz.");

                        }

                    });

                }
                else
                {
                    throw new Exception("Uzun soru tipinin cevabı birden fazla olamaz.");

                }
            }

            // EvetHayır soru tipinin Evet veya Hayır olmak üzere 1 adet cevabı olmalı
            else if (questionType == "TrueFalse")
            {
                if (answersListCount == 1)
                {
                    answersList.ForEach(a =>
                    {
                        if (a.Description == "Evet" || a.Description == "Hayır")
                        {
                            _question.Add(question);
                        }
                        else
                        {
                            throw new Exception("EvetHayır soru tipinin cevabı Evet veya Hayır olabilir.");

                        }
                    });

                }
                else
                {
                    throw new Exception("Uzun soru tipinin cevabı birden fazla olamaz.");

                }

            }

            else if (questionType == "MultipleChoice")
            {
                if (answersListCount == 1)
                {
                    var optionsList = question.Options.ToList();

                    answersList.ForEach(a =>
                    {
                        if (a.Description.Length > 0)
                        {
                            var isSame = optionsList.Any(x => x.Description == a.Description);

                            if (isSame)
                            {
                                _question.Add(question);
                            }
                            else
                            {
                                throw new Exception("Verdiğiniz cevap seçeneklerde bulunmamaktadır.");

                            }


                        }
                        else
                        {
                            throw new Exception("Cevap boş bırakılamaz.");
                        }

                    });

                }
                else
                {
                    throw new Exception("Çoktan seçmeli soru tipinin cevabı 1 adet olabilir.");

                }
            }
            else if (questionType == "CheckBox")
            {
                if (answersListCount > 0 && answersListCount <= 5)
                {
                    var optionsList = question.Options.ToList();
                    var noneControl = answersList.Any(x => x.Description == "Hiçbiri");
                    foreach (var answer in answersList)
                    {
                        if (noneControl)
                        {
                            question.NoneAnswer();
                            _question.Add(question);
                            break;
                        }
                        else
                        {
                            foreach (var options in optionsList)
                            {
                                var answerControl = optionsList.Any(x => x.Description == answer.Description);

                                if (answerControl)
                                {
                                    _question.Add(question);
                                    break;
                                }
                                else
                                {
                                    throw new Exception("Verdiğiniz cevap seçeneklerde bulunmamaktadır.");

                                }
                            }
                        }
                    }

                }
                else
                {
                    throw new Exception("Onay kutusu soru tipinin cevapları en az 1 en fazla 4 olabilir.");

                }
            }
            else if (questionType == "Date")
            {
                if (answersListCount == 1)
                {
                    answersList.ForEach(a =>
                    {
                        if (a.Date != default)
                        {

                            _question.Add(question);

                        }
                        else if (a.Description != default)
                        {
                            throw new Exception("Cevap Tarih olmalı.");

                        }
                        else
                        {
                            throw new Exception("Cevap Tarih olmalı.");

                        }

                    });
                }
                else
                {
                    throw new Exception("Tarih soru tipinin cevabı 1 adet olabilir.");

                }
            }
            return _question.ToList();
        }


    }

}
