using System.Text;

namespace Test.Calculator.Tools;

internal static class Extensions
{
    /// <summary>
    /// Prints the enumeration of elements with normal English language.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="elements">The collection of elements.</param>
    /// <param name="stringBuilder">The string builder to print the elements to.</param>
    /// <param name="print">The delegate to print an element.</param>
    public static void PrintMultiple<T>(
        this IReadOnlyList<T> elements,
        StringBuilder stringBuilder,
        Action<T> print)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements.Count == 2 && i == 1)
            {
                stringBuilder.Append(" and ");
            }

            if (elements.Count > 2 && i > 0)
            {
                if (i < elements.Count - 1)
                {
                    stringBuilder.Append(", and ");
                }
                else
                {
                    stringBuilder.Append(", ");
                }
            }

            print(elements[i]);
        }
    }
}