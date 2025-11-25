using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    public class BookMark : DecoradorSegmentoTexto
    {
        private string _name;

        public BookMark (ISegmentoTexto segment, string name) : base(segment)
        {
            _name = name;
            if (_segment is SegmentoTextoBasico basic)
            {
                basic.IsBookmarked = true;
                basic.BookmarkName = _name;
            }
        }

        public override bool IsBookmarked => true;
        public override string BookmarkName => _name;

        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[ {_name}] ");
            Console.ResetColor();
            base.Display();
        }
    }
}
