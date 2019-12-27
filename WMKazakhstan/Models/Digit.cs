using System;

namespace WMKazakhstan.Models
{
    public struct Digit
    {
        public static readonly Digit Zero = new Digit(0);

        public Digit(int number) : this()
        {
            if (number < 0 || number > 9) throw new ArgumentException(nameof(number));

            Parse(NumberToBitString(number));
        }

        public Digit(string bitString) : this()
        {
            Parse(bitString);
        }

        public bool Section0 { get; set; }
        public bool Section1 { get; set; }
        public bool Section2 { get; set; }
        public bool Section3 { get; set; }
        public bool Section4 { get; set; }
        public bool Section5 { get; set; }
        public bool Section6 { get; set; }

        public bool PosiblyEqual(Digit digit)
        {
            if (digit.Section0 && !Section0) return false;
            if (digit.Section1 && !Section1) return false;
            if (digit.Section2 && !Section2) return false;
            if (digit.Section3 && !Section3) return false;
            if (digit.Section4 && !Section4) return false;
            if (digit.Section5 && !Section5) return false;
            if (digit.Section6 && !Section6) return false;

            return true;
        }

        private string NumberToBitString(int number)
        {
            return number switch
            {
                1 => "0010010",
                2 => "1011101",
                3 => "1011011",
                4 => "0111010",
                5 => "1101011",
                6 => "1101111",
                7 => "1010010",
                8 => "1111111",
                9 => "1111011",
                _ => "1110111"
            };
        }

        public int ToNumber() => ToBitString() switch
        {
            "0010010" => 1,
            "1011101" => 2,
            "1011011" => 3,
            "0111010" => 4,
            "1101011" => 5,
            "1101111" => 6,
            "1010010" => 7,
            "1111111" => 8,
            "1111011" => 9,
            _ => 0
        };

        public string ToBitString()
        {
            var chars = new Span<char>(new char[7]);

            chars[0] = Section0 ? '1' : '0';
            chars[1] = Section1 ? '1' : '0';
            chars[2] = Section2 ? '1' : '0';
            chars[3] = Section3 ? '1' : '0';
            chars[4] = Section4 ? '1' : '0';
            chars[5] = Section5 ? '1' : '0';
            chars[6] = Section6 ? '1' : '0';

            return chars.ToString();
        }

        public override string ToString()
        {
            return ToNumber().ToString();
        }

        private void Parse(ReadOnlySpan<char> chars)
        {
            Section0 = ParseSection(chars[0]);
            Section1 = ParseSection(chars[1]);
            Section2 = ParseSection(chars[2]);
            Section3 = ParseSection(chars[3]);
            Section4 = ParseSection(chars[4]);
            Section5 = ParseSection(chars[5]);
            Section6 = ParseSection(chars[6]);
        }

        private static bool ParseSection(char ch)
        {
            return ch == '1';
        }

        public Digit Clone()
        {
            return new Digit
            {
                Section0 = Section0,
                Section1 = Section1,
                Section2 = Section2,
                Section3 = Section3,
                Section4 = Section4,
                Section5 = Section5,
                Section6 = Section6
            };
        }

        public static Digit operator -(Digit left, Digit right)
        {
            return new Digit
            {
                Section0 = diff(left.Section0, right.Section0),
                Section1 = diff(left.Section1, right.Section1),
                Section2 = diff(left.Section2, right.Section2),
                Section3 = diff(left.Section3, right.Section3),
                Section4 = diff(left.Section4, right.Section4),
                Section5 = diff(left.Section5, right.Section5),
                Section6 = diff(left.Section6, right.Section6)
            };

            static bool diff(bool a, bool b)
            {
                if (a && b) return false;

                return a;
            }
        }

        public static Digit operator +(Digit digit, int val)
        {
            var number = digit.ToNumber();

            number += val;

            if (number > 9)
                number = 9;

            return new Digit(number);
        }

        public static Digit operator -(Digit digit, int val)
        {
            var number = digit.ToNumber();

            number -= val;

            if (number < 0)
                number = 0;

            return new Digit(number);
        }
    }
}
