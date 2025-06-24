public class ResultCalculating
{
    public static string Peni(string expression)
    {
        string[] pluses = expression.Split("+");
        for (int i = 0; i < pluses.Length; i++)
        {
            if (pluses[i].Contains("-"))
            {
                string[] minuses = pluses[i].Split("-");
                for (int j = 0; j < minuses.Length; j++)
                {
                    if (minuses[j].Contains("*"))
                    {
                        string[] productes = minuses[j].Split("*");
                        for (int l = 0; l < productes.Length; l++)
                        {
                            if (productes[l].Contains("/"))
                            {
                                string[] divisers = productes[j].Split("/");
                                for (int d = 0; d < divisers.Length; d++)
                                {
                                    divisers[d+1] = Convert.ToString(Convert.ToInt32(divisers[d]) / 
                                                                     Convert.ToInt32(divisers[d + 1]));
                                }
                                productes[l] = divisers[divisers.Length];
                                Console.WriteLine(productes[l]);
                            }
                            else
                            {
                
                            }
                        }
                    }
                    else
                    {
                
                    }
                }
            }
            else
            {
                
            }
        }

        return expression;
    }
} 