using NBuySurveyFormsApp.Models;
using NBuySurveyFormsApp.Services;
using System;

namespace NBuySurveyFormsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kısa cevap
            Answers a1 = new Answers(description: "Swing trader.");
            //Uzun cevap
            Answers a2 = new Answers(description: "Yaklaşık 1 yıldır yatırım üzerine çalışmalar yapıyorum.");
            //Evet Hayır
            Answers a3 = new Answers(description: "Evet");
            Answers a33 = new Answers(description: "Hayır");
            // Multiple choice
            Answers a4 = new Answers(description: "CSPR");
            // CheckBox
            Answers a5 = new Answers(description: "BTC");
            Answers a6 = new Answers(description: "ETH");
            Answers a7 = new Answers(description: "SOL");
            Answers a8 = new Answers(description: "CSPR");
            Answers a9 = new Answers(description: "Hiçbiri");
            // Date
            Answers a10 = new Answers(date: DateTime.Now);
            Answers a11 = new Answers(description: "s");



            Options o1 = new Options(description: "Kısa cevap giriniz.");

            Options o2 = new Options(description: "Uzun cevap giriniz.");

            Options o3 = new Options(description: "Evet");
            Options o4 = new Options(description: "Hayır");

            Options o5 = new Options(description: "BTC");
            Options o6 = new Options(description: "ETH");
            Options o7 = new Options(description: "SOL");
            Options o8 = new Options(description: "CSPR");

            Options o9 = new Options(description: "BTC");
            Options o10 = new Options(description: "ETH");
            Options o11 = new Options(description: "SOL");
            Options o12 = new Options(description: "CSPR");
            Options o13 = new Options(description: "Hiçbiri");

            Options o14 = new Options(description: "Tarihi giriniz.");


            Question q1 = new Question(title: " Hangi tip yatırımcısın ? ", type: Models.Type.Short);
            q1.AddOption(o1);
            q1.AddAnswer(a1);

            Question q2 = new Question(title: " Yatırım geçmişinizden bahseder misiniz? ", type: Models.Type.Long);
            q2.AddOption(o2);
            q2.AddAnswer(a2);

            Question q3 = new Question(title: " Kripto borsası hakkında bilginiz var mı ? ", type: Models.Type.TrueFalse);
            q3.AddOption(o3);
            q3.AddOption(o4);
            q3.AddAnswer(a3); // Evet
            //q3.AddAnswer(a33); // Hayır
            //q3.AddAnswer(a4);



            Question q4 = new Question(title: " Favori kripto para biriniz hangisi? ", type: Models.Type.MultipleChoice);
            q4.AddOption(o5);
            q4.AddOption(o6);
            q4.AddOption(o7);
            q4.AddOption(o8);
            q4.AddAnswer(a4);
            //q4.AddAnswer(a3);


            Question q5 = new Question(title: " Hangi kripto paralara yatırımınız mevcut? ", type: Models.Type.CheckBox);
            q5.AddOption(o9);
            q5.AddOption(o10);
            q5.AddOption(o11);
            q5.AddOption(o12);
            q5.AddOption(o13);
            q5.AddAnswer(a5);
            q5.AddAnswer(a6);
            q5.AddAnswer(a7);
            q5.AddAnswer(a8);
            //q5.AddAnswer(a9); // Hiçbiri.


            Question q6 = new Question(title: " Tarih ", type: Models.Type.Date);
            q6.AddOption(o14);
            q6.AddAnswer(a10);


            Survey survey = new Survey(title: " Anket-1 ", description: " Anket-1 ", number: 9, date: DateTime.Now);

            survey.AddQuestion(q1);
            survey.AddQuestion(q2);
            survey.AddQuestion(q3);
            survey.AddQuestion(q4);
            survey.AddQuestion(q5);
            survey.AddQuestion(q6);

            survey.CreateSurvey();
            survey.ShowResult();
            
            Console.WriteLine("Bitti");


        }
    }
}
