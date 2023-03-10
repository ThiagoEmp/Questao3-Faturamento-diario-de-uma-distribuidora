using System;
using Newtonsoft.Json;
using Questão_3_Faturamento_diário_de_uma_distribuidora;

class Program
{
    //Questão 3 - Faturamento diário de uma distribuidora
    static void Main()
    {
        double MenorFaturamento = 0;
        double MaiorFaturamento = 0;
        double MediaFaturamento = 0;
        int DiasSuperiorAMedia = 0;
        int MenorDia = 0;
        int MaiorDia = 0;
        double SomaTotal = 0;
        int Quantidade = 0;


        string caminhoArquivo = @"C:\Users\Thiag\source\repos\Questão 3 Faturamento diário de uma distribuidora\Questão 3 Faturamento diário de uma distribuidora\dados.json";
        string conteudoArquivo = File.ReadAllText(caminhoArquivo);

        var faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(conteudoArquivo);

        foreach (var faturamento in faturamentos )
        {
            if(faturamento.valor != 0)
            {
                if(MenorFaturamento == 0)
                {
                    MenorFaturamento = faturamento.valor;
                }
                else if (faturamento.valor < MenorFaturamento)
                {
                    MenorFaturamento = faturamento.valor;
                    MenorDia = faturamento.dia;
                }
                
                if(MaiorFaturamento == 0)
                {
                    MaiorFaturamento= faturamento.valor;
                }
                else if (faturamento.valor > MaiorFaturamento)
                {
                    MaiorFaturamento = faturamento.valor;
                    MaiorDia = faturamento.dia;
                }

                SomaTotal += faturamento.valor;
                Quantidade++;

            }


        }
        MediaFaturamento = (SomaTotal / Quantidade);
        
        foreach(var faturamento in faturamentos)
        {
            if(faturamento.valor > MediaFaturamento)
            {
                DiasSuperiorAMedia++;
            }
        }

        Console.WriteLine("Menor valor de faturamento: {0}, referente ao dia: {1}", MenorFaturamento, MenorDia);
        Console.WriteLine("Maior valor de faturamento: {0}, referente ao dia: {1}", MaiorFaturamento, MaiorDia);
        Console.WriteLine("Quantidade de dias em que o faturamento foi superior a média mensal: {0}", DiasSuperiorAMedia);



        Console.ReadLine();
    }
}