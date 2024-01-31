using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DZ_7._8
{
    public struct Worker
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public DateTime RecordDate { get; set; }

        public string InfoWorker()
        {
            string s = $"АЙДИ:{Id}#ФИО{FullName}#ЛЕТ{Age}#РОСТ{Height}#ДР{BirthDate}#МР{BirthPlace}#ДАТА{RecordDate}";
            return s;
        }
    }
}

