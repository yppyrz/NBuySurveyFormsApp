using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuySurveyFormsApp.Models
{
    /// <summary>
    /// Soru tiplerini tutan class.
    /// </summary>
    public enum Type
    {
        Short, // 1 adet seçenek ve cevap olabilir. Cevap en fazla 30 karakter olabilir.
        Long,// 1 adet seçenek ve cevap olabilir. Cevap en fazla 200 karakter olabilir.
        TrueFalse,// 2 adet seçenek olabilir. Yalnızca 1 adet cevap olabilir.
        MultipleChoice,// En fazla 4 adet seçenek olabilir. 1 adet cevap olabilir.
        CheckBox,// En fazla 5 adet seçenek olabilir. Cevap birden çok olabilir ve "hiçbiri" seçilirse diğer cevaplar seçilmemiş olarak işaretlenmeli
        Date//1 seçenek ve cevap olmalı. Girilen cevap tarih formatında olmalı

    }
}
