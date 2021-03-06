using System;

namespace _2048Game
{
    class Table2048 
{   
    Cell2048[,] table ;
    public Table2048()
    {

    }
    
    
    public  void createTable(int row , int coll)
    {   
        table = new Cell2048[row,coll];
        for (int i=0; i<row ; i++)
        {
            for (int j = 0;j<coll; j++)
            {
                table[i,j] = new Cell2048();
            }
        }
        for (int i=0; i <row; i++)
        {
            for (int j =0 ; j <coll ; j++)
            {
                if (i==0)
                {
                    if (j==0) 
                    {
                        table[i,j].right = table[i,j+1];
                        table[i,j].down = table[1,j];
                    }
                    else if (j==coll-1)
                    {
                        table[i,j].left = table[0,j-1];
                        table[i,j].down = table[1,j];
                    }
                    else
                    {
                        table[i,j].left = table[0,j-1];
                        table[i,j].right = table[0,j+1];
                        table[i,j].down = table[1,j];
                    }

                }

                else if (i ==row-1)
                {
                    if (j==0) 
                    {
                        table[i,j].right = table[i,j+1];
                        table[i,j].up = table[i-1,j];
                    }
                    else if (j==coll-1)
                    {
                        table[i,j].left = table[i,j-1];
                        table[i,j].up = table[i-1,j];
                    }
                    else
                    {
                        table[i,j].left = table[i,j-1];
                        table[i,j].right = table[i,j+1];
                        table[i,j].up = table[i-1,j];
                    }
                }
                else
                {
                    if (j==0) 
                    {
                        table[i,j].right = table[i,j+1];
                        table[i,j].up = table[i-1,j];
                        table[i,j].down = table[i+1,j];
                    }
                    else if (j==coll-1)
                    {
                        table[i,j].left = table[i,j-1];
                        table[i,j].up = table[i-1,j];
                        table[i,j].down = table[i+1,j];
                    }
                    else
                    {
                        table[i,j].left = table[i,j-1];
                        table[i,j].right = table[i,j+1];
                        table[i,j].up = table[i-1,j];
                        table[i,j].down = table[i+1,j];
                    }
                }
                        Console.Write(table[i,j].value);
            }
            Console.WriteLine("\n");

        }

    }
}

class Cell2048
{
   public Cell2048 left ;
   public Cell2048 right ;
   public Cell2048 up ;
   public Cell2048 down ;
   public int value ;
    public Cell2048()
    {
        this.value =  0;
    }

}


    class Program
    {
       public static void Main(string[] args)
        {
              int i,j ;
              
              i = 4;
              j = 4;
            Table2048 table = new Table2048();
            table.createTable(i,j) ;
            Console.WriteLine("bruh...");
        }
    }
}
