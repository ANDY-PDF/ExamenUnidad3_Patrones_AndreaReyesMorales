using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    public interface ISegmentoTexto
    {
        string Text { get; }
        TextoFormato Format { get; }
        ConsoleColor? HighlightColor { get; }
        string Comment { get; }
        bool IsBookmarked { get; }
        string BookmarkName { get; }
        void Display();
    }

    public class SegmentoTextoBasico : ISegmentoTexto
    {
        public string Text { get; }
        public TextoFormato Format { get; }
        public ConsoleColor? HighlightColor { get; set; }
        public string Comment { get; set; }
        public bool IsBookmarked { get; set; }
        public string BookmarkName { get; set; }

        public SegmentoTextoBasico(string text, TextoFormato format)
        {
            Text = text;
            Format = format;
        }

        public virtual void Display()
        {
            if (HighlightColor.HasValue)
            {
                Console.BackgroundColor = HighlightColor.Value;
            }

            Console.ForegroundColor = Format.TextColor;
            Console.Write(Text);
            Console.ResetColor();
        }
    }
}
