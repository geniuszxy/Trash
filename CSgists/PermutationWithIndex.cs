using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSgists
{
	public static class PermutationWithIndex
	{
		public static E[] GetModified<E>(E[] array, int index)
		{
			var arraySize = array.Length;
			if (arraySize > 12)
				throw new NotSupportedException("Array size exceeding 12 is not yet supported");

			var factorial = 1;
			for (int i = 2; i <= arraySize; i++)
				factorial *= i;

			if (index < 0 || index >= factorial)
				throw new ArgumentOutOfRangeException(nameof(index));

            for (var currentIndex = 0; currentIndex < array.Length - 1; currentIndex++)
			{
				var div = factorial / arraySize;
				var divIndex = index / div;
				var exchangeIndex = divIndex + currentIndex;
                //Console.WriteLine($"{currentIndex} <-> {exchangeIndex}, div:{div} index: {index}");
                if (exchangeIndex != currentIndex)
					(array[currentIndex], array[exchangeIndex]) = (array[exchangeIndex], array[currentIndex]);

				factorial = div;
				arraySize--;
				index -= divIndex * div;
			}

			return array;
		}

		public static E[] GetCloned<E>(E[] array, int index)
			=> GetModified((E[])array.Clone(), index);
	}
}
