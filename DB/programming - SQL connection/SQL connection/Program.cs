using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_connection
{
    public class Program
    {
        static void Main(string[] args) 
        {
            Data.Init();
            Data.SetPlayerScore("Aloïs", -10000);
            Data.GetPlayerScores(1,1,20, false);
        }
    }
}
