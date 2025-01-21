/*
 1) Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0;
Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; }
Imprimir(SOMA);
Ao final do processamento, qual será o valor da variável SOMA?

2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.

IMPORTANTE: Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código;

3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
• O menor valor de faturamento ocorrido em um dia do mês;
• O maior valor de faturamento ocorrido em um dia do mês;
• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

IMPORTANTE:
a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;

4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
• SP – R$67.836,43
• RJ – R$36.678,66
• MG – R$29.229,88
• ES – R$27.165,48
• Outros – R$19.849,53

Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.  

5) Escreva um programa que inverta os caracteres de um string.

IMPORTANTE:
a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
b) Evite usar funções prontas, como, por exemplo, reverse;

NÃO SE ESQUEÇA DE INSERIR O LINK DO SEU REPOSITÓRIO NO GITHUB COM O CÓDIGO FONTE QUE VOCÊ DESENVOLVEU
 */

using System.Text.Json;

public class tmpJSON
{
    public int dia { get; set; }
    public double valor { get; set; }
}

class Program
{
    
    static double[] LerJSON()
    {
        try
        {
            string caminhoJSON = "D:\\Projetos-C#\\ChristopherRocha\\Prova-Target\\MainTeste\\bin\\Debug\\net8.0\\dados.json";
            string arquivoJSON = File.ReadAllText(caminhoJSON);
            //Console.WriteLine(arquivoJSON);

            var dados = JsonSerializer.Deserialize<tmpJSON[]>(arquivoJSON);
            double[] vetor = new double[dados.Length];

            
            foreach (var item in dados)
            {
                vetor[item.dia - 1] = item.valor;
            }

            //Console.WriteLine("Valores: ");
            //for (int i = 0; i < vetor.Length; i++)
            //{
            //    Console.WriteLine($"Dia {i + 1}: {vetor[i]}");
            //}

            return vetor;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: "+ex.Message);
            return null;
        }
    }



    static void testeSoma()
    {
        int indice = 13;
        int soma = 0;
        int k = 0;

        while (k < indice)
        {
            k++;
            soma += k;

        }

        Console.WriteLine("Resultado: " + soma);

    }

    static bool Fibonnaci(int valorParaVerificar)
    {
        int atual = 0; 
        int prox = 1;
        int tmp = 0;

        while(atual <= valorParaVerificar)
        {
            if(atual ==  valorParaVerificar)
            {
                return true;
            }
            else
            {
                tmp = atual;
                atual = prox;
                prox = tmp + prox;
                Console.WriteLine(atual);
            }
        }

        return false;
    }

    static void questaoVetor(double[] vetor)
    {
        double maior = int.MinValue;
        double menor = int.MaxValue;
        double total = 0;
        int diasValidos = 0;
        foreach (var c in vetor)
        {
            try
            {
                if (c != null)
                {
                    if(c > maior)
                    {
                        maior = c;
                    }
                    if (c < menor && c>0)
                    {
                        menor = c;
                    }
                    if (c > 0)
                    {
                        total += c;
                        diasValidos++;
                    }
                    
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                break;
            }
            
        }
        double media = total/vetor.Length;
        Console.WriteLine("Média de faturamento: " + media.ToString("F2"));
        Console.WriteLine("Total de faturamento: " + total.ToString("F2"));
        Console.WriteLine("Maior faturamento: " + maior.ToString("F2"));
        Console.WriteLine("Menor faturamento não contando com os zeros: " + menor.ToString("F2"));


    }

    static void calculoDistribuidora()
    {
        double SP = 67836.43;
        double RJ = 36678.66;
        double MG = 29229.88;
        double ES = 27165.48;
        double Outros = 19849.53;

        double total = RJ+MG+ES+SP+Outros;

        Console.WriteLine("Porcentagem de SP: " +((SP/total)*100).ToString("F2") + "%");
        Console.WriteLine("Porcentagem de RJ: " + ((RJ / total) * 100).ToString("F2") + "%");
        Console.WriteLine("Porcentagem de MG: " + ((MG / total) * 100).ToString("F2") + "%");
        Console.WriteLine("Porcentagem de ES: " + ((ES / total) * 100).ToString("F2") + "%");
        Console.WriteLine("Porcentagem de Outros: " + ((Outros / total) * 100).ToString("F2") + "%");

    }

    static void InverterPalvras (string palavra)
    {
        Stack<char> pilha = new Stack<char>();
        string palavraInvertida = "";

        foreach (char c in palavra)
        {
            pilha.Push(c);
            //Console.WriteLine(c);
        }

        while (pilha.Count > 0)
        {
            //Console.WriteLine(pilha.Pop());
            palavraInvertida += pilha.Pop();
        }

        Console.WriteLine(palavra);
        Console.WriteLine(palavraInvertida);
    }
    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("Digite a função que deseje escolher (aperte 0 para sair): ");
            Console.WriteLine("1 - Resolução da soma no loop ");
            Console.WriteLine("2 - Sequencia de Fibonacci (utilizei como parâmetro o valor 40) ");
            Console.WriteLine("3 - Vetor com dados de faturamento mensal advindos de um arquivo json ");
            Console.WriteLine("4 - Percentual de representação que cada estado teve dentro do valor total mensal da distribuidora ");
            Console.WriteLine("5 - Programa que inverta os caracteres de um string ( utilizei como parâmetro a palavra 'Desenvolvedor' ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    
                    break;
                case 1:
                    testeSoma();
                    break;
                case 2:
                    if (Fibonnaci(40))
                        Console.WriteLine("O número PERTENCE a sequencia");
                    else
                        Console.WriteLine("O número NÃO PERTENCE a sequencia");
                    break;
                case 3:
                    double[] vetor = LerJSON();
                    questaoVetor(vetor);
                    break;
                case 4:
                    calculoDistribuidora();
                    break;
                case 5:
                    InverterPalvras("Desenvolvedor");
                    break;
                default:
                    Console.WriteLine("Opcao invalida");
                    break;
            }
        } while (opcao != 0);

    }
    
   
}




