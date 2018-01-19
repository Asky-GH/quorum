using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Comment : Entity
    {
        // Комментарий
        public string Text { get; set; }
        public int QuestionId { get; set; }
        // Ответ (да/нет)
        public string YesNo { get; set; }
    }
}
