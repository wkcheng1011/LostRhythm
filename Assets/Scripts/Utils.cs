using System.Collections.Generic;
using System.Linq;
public class Utils
{
    private static System.Random random = new System.Random();

    public static T Urandom<T>(Dictionary<T, double> dict)
    {
        List<T> keys = new List<T>(dict.Keys);
        List<double> values = new List<double>(dict.Values);

        if (keys.Count == 1)
        {
            return keys[0];
        }

        double rand = random.NextDouble();
        double sumProbibility = values.Sum();

        sumProbibility -= dict[keys[keys.Count - 1]];

        for (int i = keys.Count - 1; i > 0; i--)
        {
            if (rand > sumProbibility)
            {
                return keys[i];
            }
            else
            {
                sumProbibility -= dict[keys[i - 1]];
            }
        }
        return keys[0];
    }
}
