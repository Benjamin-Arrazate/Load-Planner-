using System;

namespace Load_Planner_
{
    class Program
    {
        static void Main(string[] args)
        {
           objectTransport unavailable = new objectTransport("Indisponible","NA",0,"1,1") ;
            objectTransport barril  = new objectTransport("Barril","B",70,"1,2") ;
            objectTransport blsChtr = new objectTransport("Bolsa de chatarra","BC",20,"1,1") ;
            objectTransport blsPlnt = new objectTransport("Bolsa con plantas","BP",3,"1,2") ;
            objectTransport cjaLgra = new objectTransport("Caja ligera","C1",5,"1,1") ;
            objectTransport cjaPsda = new objectTransport("Caja pesada","C2",15,"1,1") ;
            objectTransport cjaVcia = new objectTransport("Caja vacia","C3",0.2,"1,1") ;
            objectTransport silla  = new objectTransport("Silla","S",4,"1,2") ;

            objectTransport[,] array2D = new objectTransport[,] { { unavailable, cjaLgra, cjaVcia, unavailable }, { blsPlnt, barril, cjaPsda, silla }, { blsPlnt, barril, blsChtr, silla}  };

            if (array2D[0,0]!=unavailable)
            {
                Console.WriteLine("La casilla superior izquierda no debe contener nada. Favor de corregir.");
            } 
            else if (array2D[0,3]!=unavailable)
            {
                Console.WriteLine("La casilla superior derecha no debe contener nada. Favor de corregir.");
            } 
            else
            {
                for (int i = 0; i < array2D.GetLength(0); i++)
                {
                    string line = "";
                    bool exitFor = false ;
                    for (int j = 0; j < array2D.GetLength(1); j++)
                    {                        
                        double objTopWght = 0 ;
                        for (int x = 0; x <= i; x ++)
                        {
                            if (array2D[x,j].objAbbr != array2D[i,j].objAbbr && array2D[x,j].objAbbr != "NA" ) 
                            { 
                                objTopWght = objTopWght + array2D[x,j].objWght;     
                            }
                        }
                        if (array2D[i,j].objWght <= objTopWght && i != 0) 
                        {
                            int rowNum = i + 1 ;
                            Console.WriteLine("El objeto \"" + array2D[i,j].objName + "\" esta siendo aplastado en la hilera " + rowNum + ".\nFavor de reacomodar."); 
                            exitFor = true ;
                            break ;
                        }

                        line = line + array2D[i, j] + "\t";                        
                    }
                    if (exitFor != false) 
                    { 
                        break ; 
                    }
                    Console.WriteLine(line);
                }
            }            
        }
    }
    public class objectTransport 
    {
        public objectTransport(string name, string abbr, double weight, string size)
        {
            objName = name ;
            objAbbr = abbr ;
            objWght = weight ;
            objSize = size ;
        }
        
        public string objName; 
        public string objAbbr;
        public double objWght; 
        //Vector size x(wide),y(vertical)
        public string objSize; 
        public override string ToString() => objAbbr ;
    }
}
