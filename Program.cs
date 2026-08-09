int[] dividendo = new int[21];
string? stringDividendo = "";
int?[] binario = new int?[21];
bool continuar = false;
string? saída = "";

do
{
    do
    {
        Console.WriteLine("\nDigite o número decimal que deseja converter para binário:");
        stringDividendo = Console.ReadLine();

        continuar = int.TryParse(stringDividendo, out dividendo[0]);

        // Verifica se a entrada é um número decimal ou se é um número negativo
        if (continuar)
        {
            if (dividendo[0] < 0)
            {
                Console.WriteLine("\nPor favor, digite um número decimal não negativo.");
                continuar = false;
                continue;
            }
            else
            {
                // Testa se o dividendo é 0 ou 1, caso contrário, realiza a divisão por 2 e calcula o resto
                if (dividendo[0] == 0)
                {
                    binario[0] = 0;
                }
                else if (dividendo[0] == 1)
                {
                    binario[0] = 1;
                }
                else
                {
                    for (int i = 0; dividendo[i] != 1; i++)
                    {
                        dividendo[i + 1] = dividendo[i] / 2;
                        binario[i] = dividendo[i] % 2;
                        if (dividendo[i + 1] == 1)
                        {
                            binario[i + 1] = 1;
                        }

                    }
                }
            }
        }
        else
        {
            Console.WriteLine("\nEntrada inválida. Por favor, digite um número decimal válido.");
            continue;
        }

    } while (continuar == false);

    Console.Clear();
    Console.WriteLine("\nO número decimal " + dividendo[0] + " em binário é: ");
    for (int j = 0; j < 21; j++)
    {
        Console.Write(binario[20 - j]);

    }
    Console.WriteLine("\n");

    Console.WriteLine("\nDigite 'Sair' para encerrar o programa ou pressione qualquer tecla para continuar.");
    saída = Console.ReadLine();
    saída = saída?.ToLower();

} while (saída != "sair");
Console.Clear();