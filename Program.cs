using System.Numerics;

BigInteger[] dividendo = new BigInteger[21];
string? stringDividendo = "";
BigInteger?[] binario = new BigInteger?[21];
bool continuar = false;
string? saída = "";
string? opçãoMenu = "";

//Cria um array que contém os multiplicadores elevados de 0 a 21, que serão utilizados para converter binário para decimal.
int[] multiplicadorElevadoDe0a21 = new int[21];
multiplicadorElevadoDe0a21[0] = 1;
multiplicadorElevadoDe0a21[1] = 2;
for (int h = 2; h < 21; h++)
{
    multiplicadorElevadoDe0a21[h] = multiplicadorElevadoDe0a21[h - 1] * multiplicadorElevadoDe0a21[1];

}

string? stringMultiplicando = "";
BigInteger multiplicando = 0;
int?[] produto = new int?[21];
int? somaDosProdutos = 0;

//Limpa o terminal antes de iniciar o programa
Console.Clear();

//loop principal do programa, que permite ao usuário escolher entre converter decimal para binário ou binário para decimal, e também permite sair do programa.
do
{
    Console.WriteLine("\t\t\tConversor Binário para Decimal e Decimal para Binário\n\n");
    Console.WriteLine("Digite 'Binário' para converter decimal para binário ou 'Decimal' para converter binário para decimal ou 'Sair' para encerrar:");
    opçãoMenu = Console.ReadLine();
    opçãoMenu = opçãoMenu?.ToLower();

    //Verifica se a opção escolhida é válida, caso contrário, solicita que o usuário digite novamente.
    if (opçãoMenu == "binário")
    {
        Console.Clear();

        //Loop que permite ao usuário converter vários números decimais para binário, até que ele escolha voltar ao menu principal.
        do
        {
            //Loop que solicita ao usuário digitar um número decimal válido, e realiza a conversão para binário.
            do
            {
                Console.WriteLine("\nDigite o número decimal que deseja converter para binário:");
                stringDividendo = Console.ReadLine();
                continuar = BigInteger.TryParse(stringDividendo, out dividendo[0]);

                // Verifica se a entrada é um número decimal ou se é um número negativo
                if (continuar)
                {
                    if (dividendo[0] < 0)
                    {
                        Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("\nEntrada inválida. Por favor, digite um número decimal válido.");
                    continue;

                }

            } while (continuar == false);

            Console.Clear();
            Console.WriteLine("\nO número decimal " + dividendo[0] + " em binário é: ");
            //Exibe o resultado da conversão de decimal para binário
            for (int i = 0; i < 21; i++)
            {
                Console.Write(binario[20 - i]);

            }

            //Limpa a saída do binário
            for (int i = 0; i < 21; i++)
            {
                binario[i] = null;

            }

            Console.WriteLine("\n");
            Console.WriteLine("\nDigite 'Voltar' para voltar ao menu principal ou pressione qualquer tecla para continuar.");
            saída = Console.ReadLine();
            saída = saída?.ToLower();
            Console.Clear();

        } while (saída != "voltar");

    }
    else if (opçãoMenu == "decimal")
    {
        Console.Clear();

        //Loop que permite ao usuário converter vários números binários para decimal, até que ele escolha voltar ao menu principal.
        do
        {
            Console.WriteLine("\nDigite o número binário que deseja converter para decimal (máximo de 21 dígitos):");
            stringMultiplicando = Console.ReadLine();
            stringMultiplicando = stringMultiplicando != null ? stringMultiplicando.Trim() : "";
            continuar = BigInteger.TryParse(stringMultiplicando, out multiplicando);

            if (stringMultiplicando.Contains("2") || stringMultiplicando.Contains("3")
            || stringMultiplicando.Contains("4") || stringMultiplicando.Contains("5")
            || stringMultiplicando.Contains("6") || stringMultiplicando.Contains("7")
            || stringMultiplicando.Contains("8") || stringMultiplicando.Contains("9"))
            {
                Console.Clear();
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número binário válido (apenas 0s e 1s).");
                continuar = false;

            }
            else if (stringMultiplicando.Length > 21)
            {
                Console.Clear();
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número binário válido com no máximo 21 dígitos.");
                continuar = false;

            }
            else if (multiplicando < 0)
            {
                Console.Clear();
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número binário válido que não seja negativo (apenas 0s e 1s).");
                continuar = false;

            }
            else if (continuar == false)
            {
                Console.Clear();
                Console.WriteLine("\nEntrada inválida. Por favor, digite um número binário e que não seja negativo.");

            }
            else if (continuar == true && multiplicando >= 0 && stringMultiplicando.Length <= 21)
            {
                string[] primeiroBinarioParaDecimal = new string[stringMultiplicando.Length];
                int quantidadeDeCaracteresDoMultiplicando = stringMultiplicando.Length;
                int[] segundoBinarioParaDecimal = new int[quantidadeDeCaracteresDoMultiplicando];
                Console.Clear();
                Console.WriteLine("\nO número binário " + stringMultiplicando + " em decimal é: ");
                for (int i = 0; i < stringMultiplicando.Length; i++)
                {
                    segundoBinarioParaDecimal[i] = (int)char.GetNumericValue(stringMultiplicando[i]);

                }

                for (int i = 0; i < quantidadeDeCaracteresDoMultiplicando; i++)
                {
                    produto[i] = segundoBinarioParaDecimal[quantidadeDeCaracteresDoMultiplicando - 1 - i] * multiplicadorElevadoDe0a21[i];
                    somaDosProdutos = somaDosProdutos + produto[i];

                }
                Console.WriteLine(somaDosProdutos);
                somaDosProdutos = 0;

            }

            Console.WriteLine("\n\nDigite 'Voltar' para voltar ao menu principal ou pressione qualquer tecla para continuar.");
            saída = Console.ReadLine();
            saída = saída?.ToLower();
            Console.Clear();

        } while (saída != "voltar");

    }
    else if (opçãoMenu == "sair")
    {
        Console.Clear();
        Console.WriteLine("\nPrograma encerrado. Obrigado por utilizar o conversor!\n\n");
        break;

    }
    else
    {
        Console.Clear();
        Console.WriteLine("\nOpção inválida. Por favor, digite 'Binário' ou 'Decimal' ou 'Sair' para encerrar.\n\n");
        continue;

    }

    Console.Clear();
    Console.WriteLine("\nDigite 'Sair' para encerrar o programa ou pressione qualquer tecla para continuar e ir ao menu principal.");
    opçãoMenu = Console.ReadLine();
    opçãoMenu = opçãoMenu?.ToLower();
    Console.Clear();

} while (opçãoMenu != "sair");