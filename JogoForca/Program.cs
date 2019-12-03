using System;



namespace JogoForca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vetor com as palavras para ser sorteadas.
            string[] palavras = {"casa", "artista", "desenvolvedor", "futebol", "software", "coca-cola"};

            // Gerando um número aleatório para sortear a palavra.
            Random random = new Random();           
           string palavraSorteada = palavras[random.Next(0, palavras.Length)];

            // Vetor com as letras separadas da palavra sorteada.
            char[] palavraQuebrada = palavraSorteada.ToCharArray();

            // Vetor com as letras que o jogador acertou.
            string[] letrasReveladas = new string[palavraQuebrada.Length];

            // Variáveis de controle de jogo.
            const int limiteErros = 7;
            int qtdErros = 0;
            char letraEscolhida;
            bool sairJogo = false;
            bool acertou = false;
            int qtdeLetras = 0;
            int qtdeAcertos = 0;

            // Monta a lista de letras reveladas.
            for (int i = 0; i < palavraQuebrada.Length; i++)
            {
                if(palavraQuebrada[i].ToString() == "-")
                {
                    letrasReveladas[i] = " - ";
                    Console.Write(letrasReveladas[i]);
                }
                else
                {
                    letrasReveladas[i] = " _ ";
                    Console.Write(letrasReveladas[i]);
                    qtdeLetras++;
                }  
            }

            while(sairJogo == false)
            {
                // Mostra para o usuário as info do jogo.
                Console.Clear();
                Console.WriteLine("### VOCÊ ESTÁ JOGANDO RODA RODA SENAC DEV ###");
                Console.WriteLine();
                Console.WriteLine("Erros: {0} de {1}", qtdErros, limiteErros);
                Console.WriteLine("A Palavra sorteada possui: {0} letras.", qtdeLetras);

                // Lista as letras reveladas.
                for (int i = 0; i < letrasReveladas.Length; i++)
                    Console.Write(letrasReveladas[i]);

                // Pergunta ao jogador o palpite de letra.
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Digite uma letra: ");
                letraEscolhida = Convert.ToChar(Console.ReadLine());

                // Reiniciar o Acerto.
                acertou = false;

                // Verifica se a letra informada tem na palavra.
                for (int i = 0; i < letrasReveladas.Length; i++)
                {
                    if(palavraQuebrada[i] == letraEscolhida)
                    {
                        acertou = true;
                        qtdeAcertos++;
                        letrasReveladas[i] = letraEscolhida.ToString();
                    }
                }

                // Validando a rodada.
                if (acertou == false)
                    qtdErros++;

                if(qtdErros >= limiteErros)
                {
                    Console.Clear();
                    Console.WriteLine("ERROOOU! QUE PENA, VOCÊ PERDEU. A palavra sorteada era: {0}.", palavraSorteada.ToUpper());
                    sairJogo = true;
                }

                if (qtdeLetras == qtdeAcertos)
                {
                    Console.Clear();
                    Console.WriteLine("PARABÉNS, VOCÊ GANHOU! Pois conseguiu descobrir a palavra {0}.", palavraSorteada.ToUpper());
                    sairJogo = true;
                }
            }

            Console.ReadKey();
            


               
            
           
            


            
        }
    }
}
