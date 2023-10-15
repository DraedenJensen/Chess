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

        /// <summary>
        /// Constructor which creates a new object and starts a new process running a chess game in Stockfish
        /// </summary>
        /// <param name="skillLevel">Expects a 1-4 value; 1 means Stockfish will play worse while 4 means Stockfish will play better</param>
        public StockfishInterface(int skillLevel) 
        {
            moveList = "";
            currentOutput = "";

            // Credit: I got help here with getting started knowing how to run a process using a command line app; I'd never done it
            // https://chess.stackexchange.com/questions/17685/how-to-send-uci-messages-from-c-app-to-stockfish-on-android
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

        /// <summary>
        /// Event handler method which runs whenever output is printed to the command line from the process.
        /// </summary>
        private void LineReturned (object sender, DataReceivedEventArgs e)
        {
            currentOutput = e.Data;
            Debug.WriteLine($"Line returned: {currentOutput}");
        }

        /// <summary>
        /// Asks Stockfish to find its best move in the current game.
        /// </summary>
        /// <param name="longNotation">The UCI notation representing the player's last move.</param>
        /// <returns>The UCI notation representing the computer's next move found by the engine.</returns>
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

        /// <summary>
        /// Closes the engine.
        /// </summary>
        public void Close()
        {
            process.Close();
        }
    }
}
