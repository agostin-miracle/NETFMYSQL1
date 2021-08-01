using System;
using System.Data;

namespace NETFMYSQL1
{
    class Program
    {
        static void Main(string[] args)
        {

            if (Connector.Get())
            {
                DataTable r = Connector.GetTable("select * from uf");

                for (int i = 0; i < r.Rows.Count; i++)
                {
                    Console.WriteLine("{0} {1} {2}", i+1, r.Rows[i][0].ToString(), r.Rows[i][1].ToString());
                }
                Console.WriteLine("Pressione qualquer tecla para continuar");
            }
            else
                Console.WriteLine("Falha de Conexão");


            Console.ReadKey();


        }
    }
}
