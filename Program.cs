using System;
System.Windows.
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

    public void slideRight(Cell2048 cell)
    {   
        
        if (cell == null) return ;
        else if (cell.right == null) return;
        if(cell.value == 0)
        {
            slideRight(cell.left);
            return;
        }
        else
        {
           if(cell.right.value == 0)
           {
               cell.right.value += cell.value ;
               cell.value = 0;
               slideRight(cell.right);
               slideRight(cell.left);
               return ;
           }
           else if (cell.value == cell.right.value)
           {
               cell.right.value += cell.value ;
               cell.value = 0;
               slideRight(cell.left);
               return;
           }
           else if (cell.value != cell.right.value)
           {
               slideRight(cell.left);
               return;
           }
            
        }
        
            
        
    }

    public void slideLeft(Cell2048 cell)
    {
        if (cell == null) return ;
        else if (cell.left == null) return;
        if(cell.value == 0)
        {
            slideLeft(cell.right);
            return;
        }
        else
        {
           if(cell.left.value == 0)
           {
               cell.left.value += cell.value ;
               cell.value = 0;
               slideLeft(cell.left);
               slideLeft(cell.right);
               return ;
           }
           else if (cell.value == cell.left.value)
           {
               cell.left.value += cell.value ;
               cell.value = 0;
               slideLeft(cell.right);
               return;
           }
           else if (cell.value != cell.left.value)
           {
               slideLeft(cell.right);
               return;
           }
            
        }
    }

    public void slideUp(Cell2048 cell)
    {
        if (cell == null) return ;
        else if (cell.up == null) return;
        if(cell.value == 0)
        {
            slideUp(cell.down);
            return;
        }
        else
        {
           if(cell.up.value == 0)
           {
               cell.up.value += cell.value ;
               cell.value = 0;
               slideUp(cell.up);
               slideUp(cell.down);
               return ;
           }
           else if (cell.value == cell.up.value)
           {
               cell.up.value += cell.value ;
               cell.value = 0;
               slideUp(cell.down);
               return;
           }
           else if (cell.value != cell.up.value)
           {
               slideUp(cell.down);
               return;
           }
            
        }
    }

    public void slideDown(Cell2048 cell)
    {
        if (cell == null) return ;
        else if (cell.down == null) return ;
        if (cell.value == 0)
        {
            slideDown(cell.up);
            return;
        }
        else
        {
            if (cell.down.value == 0)
            {
                cell.down.value += cell.value ;
                cell.value = 0 ;
                slideDown(cell.down);
                slideDown(cell.up);
                return;
            }
            else if (cell.value == cell.down.value)
            {
                cell.down.value += cell.value ;
                cell.value = 0 ;
                slideDown(cell.up);
                return;
                
            }
            else if (cell.value != cell.down.value)
            {
                slideDown(cell.up);
                return ;
            }
        }

    }

    public void drawTable(Cell2048[,] cellT)
    {
        int row = cellT.GetUpperBound(0) + 1 ;
        int coll = cellT.GetUpperBound(1) + 1 ;
        for (int i = 0; i < row ; i++)
        {
            for (int j = 0; j< coll ; j++)
            {
                Console.Write(cellT[i,j]);
            }
            Console.WriteLine("\n");
        }
    }

    public void putRandomValues(Cell2048[,] cellT)
    {   
        var rand = new Random();
        int row = cellT.GetUpperBound(0) + 1 ;
        int coll = cellT.GetUpperBound(1) + 1 ;
        int howManyValue = rand.Next(1,3) ;
        int randRow,randColl;
        while ( howManyValue > 0 )
        {
            randRow = rand.Next(row);
            randColl = rand.Next(coll);
            if (cellT[randRow,randColl].value != 0) continue ;
            else
            {
                double chance = rand.NextDouble();
                if (chance <0.75)
                {
                    cellT[randRow,randColl] = 2 ;
                }
                else if (chance>=0.75 && chance <0.98)
                {
                    cellT[randRow,randColl] = 4 ;
                }
                else 
                {
                    cellT[randRow,randColl] = 8 ;
                }

                howManyValue -= 1;
            }
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
            while(true)
            {

            }
        }

        
    }
}
