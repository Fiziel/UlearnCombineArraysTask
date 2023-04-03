namespace ArrayCombine
{
    internal class Program
    {
        public static void Main()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }

        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array.GetValue(i));
            Console.WriteLine();
        }

        public static Array Combine(params Array[] arrays)
        {
            if (arrays.Length == 0) return null;
            var type = arrays[0].GetType().GetElementType();
            int length = 0;
            for (int i = 1; i < arrays.Length; i++)
            {
                if (type != arrays[i].GetType().GetElementType()) return null;
            }
            foreach (var array in arrays)
            {
                length += array.Length;
            }
            var result = Array.CreateInstance(type, length);
            var resultIndex = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                Array.Copy(arrays[i], 0, result, resultIndex, arrays[i].Length);
                resultIndex += arrays[i].Length;
            }
            return result;
        }
    }
}