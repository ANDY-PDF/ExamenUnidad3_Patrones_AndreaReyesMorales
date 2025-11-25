using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    public class TextoFormato
    {
        public string FontFamily { get; }
        public int FontSize { get; }
        public ConsoleColor TextColor { get; }
        public bool IsBold { get; }

        public TextoFormato(string fontFamily, int fontSize, ConsoleColor textColor, bool isBold)
        {
            FontFamily = fontFamily;
            FontSize = fontSize;
            TextColor = textColor;
            IsBold = isBold;
        }

        public override bool Equals(object obj)
        {
            if (obj is TextoFormato other)
            {
                return FontFamily == other.FontFamily &&
                       FontSize == other.FontSize &&
                       TextColor == other.TextColor &&
                       IsBold == other.IsBold;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FontFamily, FontSize, TextColor, IsBold);
        }
    }
}
