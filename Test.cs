using Microsoft.Win32.SafeHandles;

namespace ConsoleApp1;

class Test
{
    static void Main()
    {
        string expression = "128-12+5/10*20-3/2";
        expression = "2/4-4+11/10-24/2*3/6*4-2";
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
                                productes[l] = Division(productes[l]);
                            }
                        }
                        if (productes.Length > 1)
                        {
                            for (int p = 1; p < productes.Length; p++)
                            {
                                productes[p] = Convert.ToString(Convert.ToDouble(productes[p-1]) * Convert.ToDouble(productes[p]));
                            }
                            minuses[j] = productes[productes.Length - 1];
                        }
                        else
                        {
                            minuses[j] = productes[0];
                        }
                        // Console.WriteLine(minuses[j]);
                    }
                    else if (minuses[j].Contains("/"))
                    {
                        minuses[j] = Division(minuses[j]);
                    }
                    // Console.WriteLine(minuses[j]);
                }
                
                
                if (minuses.Length > 1)
                {
                    for (int p = 1; p < minuses.Length; p++)
                    {
                        minuses[p] = Convert.ToString(Convert.ToDouble(minuses[p-1]) - Convert.ToDouble(minuses[p]));
                    }
                    pluses[i] = minuses[minuses.Length - 1];
                }
                else
                {
                    pluses[i] = minuses[0];
                }
                Console.WriteLine(pluses[i]);
            }
            
            
            else
            {
                if (pluses[i].Contains("*"))
                {
                    string[] productes = pluses[i].Split("*");
                    for (int l = 0; l < productes.Length; l++)
                    {
                        if (productes[l].Contains("/"))
                        {
                            productes[l] = Division(productes[l]);
                        }
                    }
                    if (productes.Length > 1)
                    {
                        for (int p = 1; p < productes.Length; p++)
                        {
                            productes[p] = Convert.ToString(Convert.ToDouble(productes[p-1]) * Convert.ToDouble(productes[p]));
                        }
                        pluses[i] = productes[productes.Length - 1];
                    }
                    else
                    {
                        pluses[i] = productes[0];
                    }

                }
                else if (pluses[i].Contains("/"))
                {
                    pluses[i] = Division(pluses[i]);
                }
            }
            
            if (pluses.Length > 1)
            {
                for (int p = 1; p < pluses.Length; p++)
                {
                    pluses[p] = Convert.ToString(Convert.ToDouble(pluses[p-1]) + Convert.ToDouble(pluses[p]));
                }
                pluses[i] = pluses[pluses.Length - 1];
            }
            else
            {
                pluses[i] = pluses[0];
            }
        }
    }

    static string Division(string expression)
    {
        string[] divisers = expression.Split("/");
        for (int d = 1; d < divisers.Length; d++)
        {
            divisers[d] = Convert.ToString(Convert.ToDouble(divisers[d-1]) / Convert.ToDouble(divisers[d]));
        }
        return divisers[divisers.Length - 1];
    }
}