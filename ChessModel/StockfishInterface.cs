using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ChessModels
{
    public class StockfishInterface
    {
        private Process process;
        private string moveList;
        private int depth;
        string currentOutput;
        public StockfishInterface(int skillLevel) 
        {
            moveList = "";
            currentOutput = "";

            Debug.WriteLine($"File path: {Path.GetFullPath(".\\..\\..\\..\\..\\Chess\\stockfish\\stockfish-windows-x86-64-avx2.exe")}");
            ProcessStartInfo data = new ProcessStartInfo()
            {
                FileName = Path.GetFullPath(".\\..\\..\\..\\..\\Chess\\stockfish\\stockfish-windows-x86-64-avx2.exe"),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };

            process = new Process();
            process.StartInfo = data;

            process.OutputDataReceived += LineReturned;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            process.StandardInput.WriteLine("ucinewgame");
            process.StandardInput.WriteLine("isready");

            switch (skillLevel)
            {
                case 1:
                    process.StandardInput.WriteLine("setoption name Skill Level value 3");
                    process.StandardInput.WriteLine("setoption name Slow Mover value 50");
                    depth = 1;
                    break;
                case 2:
                    process.StandardInput.WriteLine("setoption name Skill Level value 9");
                    process.StandardInput.WriteLine("setoption name Slow Mover value 150");
                    depth = 3;
                    break;
                case 3:
                    process.StandardInput.WriteLine("setoption name Skill Level value 15");
                    process.StandardInput.WriteLine("setoption name Slow Mover value 250");
                    depth = 6;
                    break;
                case 4:
                    process.StandardInput.WriteLine("setoption name Skill Level value 20");
                    process.StandardInput.WriteLine("setoption name Slow Mover value 400");
                    depth = 12;
                    break;
            }
        }

        private void LineReturned (object sender, DataReceivedEventArgs e)
        {
            currentOutput = e.Data;
            Debug.WriteLine($"Line returned: {currentOutput}");
        }

        public string PassMoveToEngine(string longNotation)
        {
            currentOutput = "";
            moveList += " " + longNotation;
            Debug.WriteLine("Move list: " + moveList);
            process.StandardInput.WriteLine($"position startpos moves {moveList}");
            process.StandardInput.WriteLine($"go depth {depth}");

            while (!currentOutput.StartsWith("bestmove ")) { }
            currentOutput = currentOutput.Substring(9);
            currentOutput = currentOutput.Split(' ')[0];
            moveList += " " + currentOutput;
            Debug.WriteLine($"Move returned: {currentOutput}");

            return currentOutput;
        }

        public void Close()
        {
            process.Close();
        }
    }
}
