using System;

namespace NumerosALetra
{
    public static class Extension
    {
        public static string ToText(this long value) =>
            ConvertToText(value, false).Trim();

        public static string ToText(this int value) =>
            ConvertToText(value, false).Trim();

        private static string ConvertToText(long value, bool hasPreviousValue = true)
        {
            string text;
            long m = 1000000,
                m2 = 2000000,
                b = 1000000000000,
                b2 = 2000000000000,
                t = 1000000000000000000,
                t2 = 2000000000000000000;

            if (value < 0)
                return "menos " + ConvertToText(Math.Abs(value), false);

            text = FixedValues(value, hasPreviousValue);

            if (text != null)
                return text;

            if (value < m)
                return GroupToText((int)value, hasPreviousValue);

            if (value < m2)
                return $"un millón {ConvertToText(value % m)}";

            if (value < b)
            {
                text = $"{ConvertToText(value / m)} millones";
                if ((value - (value / m) * m) > 0)
                    text = $"{text} {ConvertToText(value - (value / m) * m)}";
                return text;
            }

            if (value < b2)
                return $"un billón {ConvertToText(value % b)}";

            if (value < t)
            {
                text = $"{ConvertToText(value / b)} billones";
                if ((value - (value / b) * b) > 0)
                    text = $"{text} {ConvertToText(value - (value / b) * b)}";
                return text;
            }

            if (value < t2)
                return $"un trillón {ConvertToText(value % t)}";

            text = $"{ConvertToText(value / t)} trillones";
            if ((value - (value / t) * t) > 0)
                text = $"{text} {ConvertToText(value - (value / t) * t)}";

            if (text != "cero" && text.EndsWith("cero"))
                text = text.Substring(0, text.LastIndexOf(" cero"));

            return text;
        }

        private static string GroupToText(int value, bool hasPreviousValue = false)
        {
            string text = FixedValues(value, hasPreviousValue);

            if (!string.IsNullOrEmpty(text))
                return text;

            if (value < 20)
                return $"dieci{ConvertToText(value - 10)}";

            if (value < 30)
                return $"veinti{ConvertToText(value - 20)}";

            if (value < 100)
            {
                int u = value % 10;
                return $"{ConvertToText((value / 10) * 10)} y {(u == 1 ? "un" : ConvertToText(value % 10))}";
            }

            if (value < 200)
                return $"ciento {ConvertToText(value - 100)}";

            if (value < 1000)
                return $"{ConvertToText((value / 100) * 100)} {ConvertToText(value % 100)}";

            if (value < 2000)
                return $"mil {ConvertToText(value % 1000)}";

            text = $"{ConvertToText(value / 1000)} mil";
            if ((value % 1000) > 0)
                text = $"{text} {ConvertToText(value % 1000)}";
            return text;
        }

        private static string FixedValues(long value, bool hasPreviousValue = false)
        {
            switch (value)
            {
                case 0: return  hasPreviousValue ? "" : "cero";
                case 1: return "uno";
                case 2: return "dos";
                case 3: return "tres";
                case 4: return "cuatro";
                case 5: return "cinco";
                case 6: return "seis";
                case 7: return "siete";
                case 8: return "ocho";
                case 9: return "nueve";
                case 10: return "diez";
                case 11: return "once";
                case 12: return "doce";
                case 13: return "trece";
                case 14: return "catorce";
                case 15: return "quince";
                case 20: return "veinte";
                case 30: return "treinta";
                case 40: return "cuarenta";
                case 50: return "cincuenta";
                case 60: return "sesenta";
                case 70: return "setenta";
                case 80: return "ochenta";
                case 90: return "noventa";
                case 100: return "cien";
                case 200:
                case 300:
                case 400:
                case 600:
                case 800:
                    return $"{ConvertToText(value / 100)}cientos";
                case 500: return "quinientos";
                case 700: return "setecientos";
                case 900: return "novecientos";
                case 1000: return "mil";
                case 1000000: return "un millón";
                default: return null;
            }
        }
    }
}
