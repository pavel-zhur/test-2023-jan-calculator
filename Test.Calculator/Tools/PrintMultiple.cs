using System.Text;

namespace Test.Calculator.Tools;

internal static class Extensions
{
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