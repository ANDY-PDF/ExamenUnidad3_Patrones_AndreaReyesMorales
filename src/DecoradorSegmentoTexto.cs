using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    public abstract class DecoradorSegmentoTexto : ISegmentoTexto
    {
        protected ISegmentoTexto _segment;

        public DecoradorSegmentoTexto(ISegmentoTexto segment)
        {
            _segment = segment;
        }

        public virtual string Text => _segment.Text;
        public virtual TextoFormato Format => _segment.Format;
        public virtual ConsoleColor? HighlightColor => _segment.HighlightColor;
        public virtual string Comment => _segment.Comment;
        public virtual bool IsBookmarked => _segment.IsBookmarked;
        public virtual string BookmarkName => _segment.BookmarkName;

        public virtual void Display()
        {
            _segment.Display();
        }

    }
    
}
