using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    public class CommentDecorator : DecoradorSegmentoTexto
    {
        private string _comment;
        private DateTime _timestamp;

        public CommentDecorator(ISegmentoTexto segment, string comment) : base(segment)
        {
            _comment = comment;
            _timestamp = DateTime.Now;
            if (_segment is SegmentoTextoBasico basic)
            {
                basic.Comment = _comment;
            }
        }

        public override string Comment => _comment;

        public override void Display()
        {
            base.Display();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" [{_comment}]");
            Console.ResetColor();
        }

    }
}
