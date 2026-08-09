int[] dividendo = new int[21];
string? stringDividendo = "";
int?[] binario = new int?[21];
bool continuar = false;
string? saída = "";
string? opçãoMenu = "";

//Limpa o terminal antes de iniciar o programa
Console.Clear();

//loop principal do programa, que permite ao usuário escolher entre converter decimal para binário ou binário para decimal, e também permite sair do programa.
do
{


    Console.WriteLine("\t\t\tConversor Binário para Decimal e Decimal para Binário\n");
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
            //Exibe o resultado da conversão de decimal para binário
            for (int j = 0; j < 21; j++)
            {
                Console.Write(binario[20 - j]);

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
        //Loop que permite ao usuário converter vários números binários para decimal, até que ele escolha voltar ao menu principal.

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