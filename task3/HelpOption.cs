using ConsoleTables;

namespace task3;

public class HelpOption
{
    public void DrawTable(string[] moves, Rule[,] rules)
    {
        var header = new string[] { "" }.Concat(moves).ToArray();
        var table = new ConsoleTable(header);
        for (int i = 0; i < moves.Length; i++)
        {
            var move = moves[i];
            object[] row = new object[moves.Length + 1];
            row[0] = move;

            for (int j = 0; j < moves.Length; j++)
            {
                row[j + 1] = rules[i, j].ToString();
            }

            table.AddRow(row);
        }
        
        table.Write();
    }

    private void DrawLine(string[] moves)
    {
        int sumLength = CalculatorLengthOfTable(moves) + MaxLengthOfMovesName(moves);
        DrawRowLine(sumLength);
    }

    private int MaxLengthOfMovesName(string[] moves)
    {
        int max = moves[0].Length;
        for (int i = 1; i <moves.Length; i++)
        {
            if (moves[i].Length > max)
            {
                max = moves[i].Length+2;
            }
        }
        return max;
    }

    private int CalculatorLengthOfTable(string[] moves)
    {
        return moves.Sum(t => t.Length + 2);
    }

    private void WriteToConsole(string message)
    {
        Console.WriteLine(message);
    }

    private void DrawRowLine(int lengthLine)
    {
        for (int i = 0; i <lengthLine ; i++)
        {
            Console.Write('_');
        }
        Console.WriteLine();
    }
}