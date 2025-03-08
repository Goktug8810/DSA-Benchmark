using System;

namespace Utils
{
    /// <summary>
    /// CollidingKey, her örneğinde sabit bir hash kodu döndürür.
    /// Böylece, hash tabanlı yapılarda tüm öğeler aynı bucket’da toplanarak yoğun collision simüle edilir.
    /// </summary>
    public class CollidingKey : IComparable<CollidingKey>
    {
        public int Value { get; }
        public CollidingKey(int value)
        {
            Value = value;
        }
        public override int GetHashCode()
        {
            return 42; // Tüm key'ler aynı hash değerine sahip
        }
        public override bool Equals(object obj)
        {
            if (obj is CollidingKey other)
                return Value == other.Value;
            return false;
        }
        public int CompareTo(CollidingKey other)
        {
            return Value.CompareTo(other.Value);
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}