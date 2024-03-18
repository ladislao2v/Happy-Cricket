using System;
using System.Linq;

namespace Code.Extensions
{
    public static class ArrayExtensions
    {
        public static int FindIndex<T>(this T[] array, T item)
        {
            var pair = array
                .Select((element, index) => new { element, index })
                .FirstOrDefault(x => x.element.Equals(item));

            return pair != null ? pair.index : -1;
        }
        
        public static T[] SortRandomly<T>(this T[] array)
        {
            Random random = new Random();
            
            return array.OrderBy(n => random.Next()).ToArray();
        }
    }
}