using System.Collections.Generic;

namespace PersonsList.Models.Extensions
{
    public static class SwapExtension
    {
        public static void Swap<T>(this List<T> list, int firstElementIndex, int secondElementIndex)
        {
            T temp = list[firstElementIndex];
            list[firstElementIndex] = list[secondElementIndex];
            list[secondElementIndex] = temp;
        }
    }
}
