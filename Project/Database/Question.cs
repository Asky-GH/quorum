using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Question : Entity
    {
        // Вопрос
        public string Text { get; set; }
        // Кол-во голосов за
        public int Yes { get; set; }
        // Кол-во голосов против
        public int No { get; set; }
    }
}
