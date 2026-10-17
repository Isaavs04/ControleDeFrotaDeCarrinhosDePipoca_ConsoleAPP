using System;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {

        double[] carrinhos = new double[20];

        int[] doce = new int[20];
        /*Quantidade de pipoca doce*/
        int[] salgada = new int[20];
        /*Quantidade de pipoca salgada*/
        double[] vl_doce = new double[20];
        /*Armazena o valor da pipoca doce*/
        double[] vl_salgada = new double[20];
        /*Armazena o valor da pipoca salgada*/
        double[] Total_carrinho = new double[20];
        const double Pipoca_doce = 3, Pipoca_salgada = 2;
        /*Valores das pipocas salgada e doce*/
        string opcao, continuar = "S";
        /*opcao controla a entrada do switch, continuar controla o principal do while*/
        double valorTotal = 0, valorTotal_doce = 0, valorTotal_salgada = 0;
        /*valotTotal valor total do faturamneto, valor total da doce e salgada*/
        int qtde_doce = 0, qtde_sal = 0;
        /*nm_carrinho será usada pelo usuário para digitar o número do carrinho*/
        do
        {
            opcao = Menu();

            switch (opcao)
            {
                case "0":
                    continuar = Saida();
                    break;
                /*Esse case pega o número do carro, atribui a ele a quantidade de doce e salgada, o valor total de doce e salgada e o total global de doce/salgada/valor*/
                case "1":
                    Registro(doce, salgada, vl_doce, vl_salgada, Total_carrinho, Pipoca_doce, Pipoca_salgada, ref valorTotal_doce, ref valorTotal_salgada, ref qtde_doce, ref qtde_sal, ref valorTotal);
                    break;
                case "2":
                    Tabela(doce, vl_doce, salgada, vl_salgada, Total_carrinho, qtde_doce, valorTotal_doce, qtde_sal, valorTotal_salgada, valorTotal);
                    break;
                case "3":
                    MAiorLucro(Total_carrinho);
                    break;
                case "4":
                    MenorLucro(Total_carrinho);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A opções digitadas não está na lista de opções, tente novamnete");
                    Console.ResetColor();
                    break;
            }
        } while (continuar == "S");
        Console.ReadKey();
    }
    //Metodo Menu
    static string Menu()
    {
        Console.Write("\n\tOPÇÕES\n\t0. Finalizar\n\t1. Lançar venda\n\t2. Mapa de faturamento\n\t3. Carrinho com maior faturamento\n\t4. Carrinho com menor faturamento\n\tInforme a opção desejada:  ");
        string opcao = Console.ReadLine();
        return opcao;
    }
    //Case 0 - saída
    static string Saida()
    {
        Loading();
        Console.Write("Saiando do programa");
        Thread.Sleep(1500);
        Console.WriteLine("\n\nTenha um bom dia!!");
        string continuar = "N";
        return continuar;

    }
    static void Loading()
    {
        Console.Clear();
        Console.WriteLine("█▒▒▒▒▒▒▒▒▒");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("███▒▒▒▒▒▒▒");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("█████▒▒▒▒▒");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("███████▒▒▒");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("██████████");
        Thread.Sleep(1000);
        Console.Clear();
    }
    //Uma função para cada case
    //case 1
    static void Registro(int[] doce, int[] salgada, double[] vl_doce, double[] vl_salgada, double[] Total_carrinho, double Pipoca_doce, double Pipoca_salgada, ref double valorTotal_doce, ref double valorTotal_salgada, ref int qtde_doce, ref int qtde_sal, ref double valorTotal)
    {
        int nm_carrinho;
        do
        {
            Console.Write("Digite o número do carrinho(0 a 20):  ");
            nm_carrinho = int.Parse(Console.ReadLine());
            if (nm_carrinho < 0 || nm_carrinho > 20)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O número digitado é inválido, tente novamente a seguir");
                Console.ResetColor();
            }
        } while (nm_carrinho < 0 || nm_carrinho > 20);

        do
        {
            Console.Write($"Número de pacotes de pipoca salgada vendidos pelo carrinho {nm_carrinho}:  ");
            salgada[nm_carrinho - 1] = int.Parse(Console.ReadLine());
            if (salgada[nm_carrinho - 1] < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Venda inválida, tente novamente a seguir");
                Console.ResetColor();
            }
        } while (salgada[nm_carrinho - 1] < 0);

        do
        {
            Console.Write($"Número de pacotes de pipoca doce vendidos pelo carrinho {nm_carrinho}:  ");
            doce[nm_carrinho - 1] = int.Parse(Console.ReadLine());
            if (doce[nm_carrinho - 1] < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Venda inválida, tente novamente a seguir");
                Console.ResetColor();
            }
        } while (doce[nm_carrinho - 1] < 0);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Vendas registradas com sucesso!!");
        Console.ResetColor();

        if (doce[nm_carrinho - 1] > 0)
        {
            vl_doce[nm_carrinho - 1] = doce[nm_carrinho - 1] * Pipoca_doce;
            valorTotal_doce = valorTotal_doce + vl_doce[nm_carrinho - 1];
            qtde_doce = doce[nm_carrinho - 1] + qtde_doce;
        }

        if (salgada[nm_carrinho - 1] > 0)
        {
            vl_salgada[nm_carrinho - 1] = salgada[nm_carrinho - 1] * Pipoca_salgada;
            valorTotal_salgada = valorTotal_salgada + (salgada[nm_carrinho - 1] * Pipoca_salgada);
            qtde_sal = salgada[nm_carrinho - 1] + qtde_sal;
        }

        Total_carrinho[nm_carrinho - 1] = vl_salgada[nm_carrinho - 1] + vl_doce[nm_carrinho - 1];
        valorTotal = valorTotal_doce + valorTotal_salgada;
    }
    static void Tabela(int[] doce, double[] vl_doce, int[] salgada, double[] vl_salgada, double[] Total_carrinho, int qtde_doce, double valorTotal_doce, int qtde_sal, double valorTotal_salgada, double valorTotal)
    {
        Loading();
        Console.WriteLine("=========================================================================");
        Console.WriteLine("|           |      Pipoca Doce      |     Pipoca Salgada    |           |");
        Console.WriteLine("|  Carrinho |-----------------------+-----------------------|   Total   |");
        Console.WriteLine("|           |    Qtde   |   Valor   |    Qtde   |   Valor   |           |");
        Console.WriteLine("|-----------+-----------+-----------+-----------+-----------+-----------|");

        for (int carrinho = 0; carrinho < 20; carrinho++)
        {
            Console.WriteLine("|    {0:00}     |{1,10} |{2,10:N2} |{3,10} |{4,10:N2} |{5,10:N2} |",
                carrinho + 1, doce[carrinho], vl_doce[carrinho], salgada[carrinho], vl_salgada[carrinho], Total_carrinho[carrinho]);
        }

        Console.WriteLine("|-----------+-----------+-----------+-----------+-----------+-----------|");
        Console.WriteLine("|Total geral|{0,10} |{1,10:N2} |{2,10} |{3,10:N2} |{4,10:N2} |",
            qtde_doce, valorTotal_doce, qtde_sal, valorTotal_salgada, valorTotal);
        Console.WriteLine("=========================================================================");
        Thread.Sleep(3000);
    }
    static void MAiorLucro(double[] Total_carrinho)
    {
        double maior = 0;
        int carrinho__MaiorLuucro = 0;
        bool temRegistroMaior = false;

        for (int i = 0; i < 20; i++)
        {
            if (Total_carrinho[i] > 0)
            {
                temRegistroMaior = true;
                if (maior == 0 || Total_carrinho[i] > maior)
                {
                    maior = Total_carrinho[i];
                    carrinho__MaiorLuucro = i;
                }
            }
        }
        if (maior == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("!!Nenhuum valor registrado no momento!!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Carrinho que mais faturou: {carrinho__MaiorLuucro + 1}\n Valor das vendas:  {maior}");
        }
        maior = 0;
        carrinho__MaiorLuucro = 0;
    }
    static void MenorLucro(double[] Total_carrinho)
    {
        double menor = 0;
        int carrinho__MenorLuucro = 0;
        bool temRegistroMenor = false;
        for (int i = 0; i < 20; i++)
        {
            if (Total_carrinho[i] > 0)
            {
                temRegistroMenor = true;
                if (menor == 0 || Total_carrinho[i] < menor)
                {
                    menor = Total_carrinho[i];
                    carrinho__MenorLuucro = i;
                }
            }
        }
        if (menor == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("!!Nenhuum valor registrado no momento!!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Carrinho que menos faturou: {carrinho__MenorLuucro + 1}\n Valor das vendas:  {menor}");
        }
        menor = 0;
        carrinho__MenorLuucro = 0;
    }
}
