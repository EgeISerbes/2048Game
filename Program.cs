using System;
using System.Text;
namespace _2048Game
{
    class Table2048 
{   
  public  Cell2048[,] table ;
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
                        
            }
            

        }

    }

    public void slideRight(Cell2048 cell)
    {   
        
        if (cell == null) return ;
        else if (cell.right == null) 
        {
            slideRight(cell.left);
            return ;
        } 
        if(cell.value == 0)
        {
            slideRight(cell.left);
            return;
        }
        else
        {
           if(cell.right.value == 0)
           {    
               Cell2048 temp = new Cell2048() ;
               temp = cell.right ;
               while (temp.right != null && temp.right.value == 0)
               {
                   temp = temp.right ; 

               }
               temp.value += cell.value ;
               cell.value = 0;
               if(temp.right != null)
               {
                    if (temp.right.value == temp.value)
                    {
                        if (!temp.right.hasChanged)
                        {
                            temp.right.value += temp.value ;
                            temp.value = 0;
                            temp.right.hasChanged = true ;
                            slideRight(cell.left);
                        }
                        else
                        {   
                            temp.right.hasChanged = false ;
                            slideRight(cell.left);
                        }
                   
                    }
                    else
                    {
                        slideRight(cell.left);
                    }
               }
               else
               {
                   slideRight(cell.left);
               }

           }
           else if (cell.value == cell.right.value)
           {    
               if (!cell.right.hasChanged)
               {

               
               cell.right.value += cell.value ;
               cell.value = 0;
               cell.right.hasChanged = true ;
               slideRight(cell.left);
               return;

               }
               else 
               {
                   cell.right.hasChanged = false ;
                   slideRight(cell.left);
               }
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
        else if (cell.right == null) 
        {
            slideLeft(cell.right);
            return ;
        } 
        if(cell.value == 0)
        {
            slideLeft(cell.right);
            return;
        }
        else
        {
           if(cell.left.value == 0)
           {    
               Cell2048 temp = new Cell2048() ;
               temp = cell.left ;
               while (temp.left != null && temp.left.value == 0)
               {
                   temp = temp.left ; 

               }
               temp.value += cell.value ;
               cell.value = 0;
               if(temp.left != null)
               {
                    if (temp.left.value == temp.value)
                    {
                        if (!temp.left.hasChanged)
                        {
                            temp.left.value += temp.value ;
                            temp.value = 0;
                            temp.left.hasChanged = true ;
                            slideLeft(cell.right);
                        }
                        else
                        {   
                            temp.left.hasChanged = false ;
                            slideLeft(cell.right);
                        }
                   
                    }
                    else
                    {
                        slideLeft(cell.right);
                    }
               }
               else
               {
                   slideLeft(cell.right);
               }

           }
           else if (cell.value == cell.left.value)
           {    
               if (!cell.left.hasChanged){
               cell.left.value += cell.value ;
               cell.value = 0;
               cell.left.hasChanged = true ;
               slideLeft(cell.right);
               return;
               
               }
               else{
                   cell.left.hasChanged = false ;
                   slideLeft(cell.right);
               }
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
        else if (cell.up == null) 
        {   
            slideUp(cell.down);
            return;
        }
        if(cell.value == 0)
        {
            slideUp(cell.down);
            return;
        }
        else
        {
           if(cell.up.value == 0)
           {    
               Cell2048 temp = new Cell2048() ;
               temp = cell.up ;
               while (temp.up != null && temp.up.value == 0)
               {
                   temp = temp.up ; 

               }
               temp.value += cell.value ;
               cell.value = 0;
               if(temp.up != null)
               {
                    if (temp.up.value == temp.value)
                    {
                        if (!temp.up.hasChanged)
                        {
                            temp.up.value += temp.value ;
                            temp.value = 0;
                            temp.up.hasChanged = true ;
                            slideUp(cell.down);
                        }
                        else
                        {   
                            temp.up.hasChanged = false ;
                            slideUp(cell.down);
                        }
                   
                    }
                    else
                    {
                        slideUp(cell.down);
                    }
               }
               else
               {
                   slideUp(cell.down);
               }

           }
           else if (cell.value == cell.up.value)
           {    
               if (!cell.up.hasChanged)
               {cell.up.value += cell.value ;
               cell.value = 0;
               cell.up.hasChanged = true;
               slideUp(cell.down);
               return;
               
               }
               else 
               {
                   cell.up.hasChanged = false ;
                   slideUp(cell.down);
               }
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
        else if (cell.down == null) {
            slideDown(cell.up);
            return ;
            }
        if (cell.value == 0)
        {
            slideDown(cell.up);
            return;
        }
        else
        {
            if(cell.down.value == 0)
           {    
               Cell2048 temp = new Cell2048() ;
               temp = cell.down ;
               while (temp.down != null && temp.down.value == 0)
               {
                   temp = temp.down ; 

               }
               temp.value += cell.value ;
               cell.value = 0;
               if(temp.down != null)
               {
                    if (temp.down.value == temp.value)
                    {
                        if (!temp.down.hasChanged)
                        {
                            temp.down.value += temp.value ;
                            temp.down.hasChanged = true ;
                            temp.value = 0;
                            slideDown(cell.up);
                        }
                        else
                        {   
                            temp.down.hasChanged = false ;
                            slideDown(cell.up);
                        }
                   
                    }
                    else
                    {
                        slideDown(cell.up);
                    }
               }
               else
               {
                   slideDown(cell.up);
               }

           }
            else if (cell.value == cell.down.value)
            {   
                if ( !cell.down.hasChanged) {
                cell.down.value += cell.value ;
                cell.value = 0 ;
                cell.down.hasChanged = true ;
                slideDown(cell.up);
                return;

                }
                else 
                {
                    cell.down.hasChanged = false ;
                    slideDown(cell.up) ;
                }
                
            }
            else if (cell.value != cell.down.value)
            {
                slideDown(cell.up);
                return ;
            }
        }

    }

    public void drawTable()
    {
        int row = table.GetUpperBound(0) + 1 ;
        int coll = table.GetUpperBound(1) + 1 ;
        for (int i = 0; i < row ; i++)
        {
            for (int j = 0; j< coll ; j++)
            {
                Console.Write(table[i,j].value);
            }
            Console.WriteLine("\n");
        }
    }

    public void putRandomValues()
    {   
        var rand = new Random();
        int row = table.GetUpperBound(0) + 1 ;
        int coll = table.GetUpperBound(1) + 1 ;
        int howManyValue = rand.Next(2,4) ;
        int randRow,randColl;
        while ( howManyValue > 0 )
        {
            randRow = rand.Next(row);
            randColl = rand.Next(coll);
            if (table[randRow,randColl].value != 0) continue ;
            else
            {
                double chance = rand.NextDouble();
                if (chance <0.75)
                {
                    table[randRow,randColl].value = 2 ;
                }
                else if (chance>=0.75 && chance <0.98)
                {
                    table[randRow,randColl].value = 4 ;
                }
                else 
                {
                    table[randRow,randColl].value = 8 ;
                }

                howManyValue -= 1;
            }
        }
    }

    public void ClearHC()
    {
        int row = table.GetUpperBound(0) + 1 ;
        int coll = table.GetUpperBound(1) + 1 ;
        for (int i = 0; i < row ; i++)
        {
            for (int j = 0; j< coll ; j++)
            {
                table[i,j].hasChanged = false ;
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

   public bool hasChanged ;
    public Cell2048()
    {
        this.value =  0;
        hasChanged = false ;
    }

}

class Game2048 : Table2048
{   
    ConsoleKeyInfo input ;
    int row,coll ;
    bool isOver ;
    public  Game2048(int row , int coll)
    {
        this.row = row ;
        this.coll = coll ;
        isOver = false ;
    }

    public void StartGame()
    {   
        

        Console.WriteLine("Press Space to start , Esc to stop the game, P to pause the game");
         input = Console.ReadKey(true) ;
                if (input.Key.ToString() == "Spacebar")
                {  
                    /*do
                    { 
                    input = Console.ReadKey(true);
                    createTable(this.row,this.coll);
                    putRandomValues();
                    drawTable();
                    
                    if (input.Key.ToString() == "W")
                    {
                        UpPressed();
                    }
                    else if (input.Key.ToString() == "S")
                    {
                        DownPressed();
                    }
                    else if (input.Key.ToString() == "A")
                    {
                        LeftPressed();
                    }
                    else if (input.Key.ToString() == "D")
                    {
                        RightPressed();
                    }
                    Console.Clear();
                    putRandomValues();
                    drawTable();
                    isOver = isGameOver();
                    } while (input.Key != ConsoleKey.Escape && !isOver) ; */

                }

                createTable(this.row,this.coll);
                putRandomValues();
                drawTable();
                Console.WriteLine("\n");  
                slideLeft(table[0,0]);
                slideLeft(table[1,0]);
                slideLeft(table[2,0]);
                slideLeft(table[3,0]);
                putRandomValues();
                drawTable();
                ClearHC();
                Console.WriteLine("\n");
                slideRight(table[0,3]);
                slideRight(table[1,3]);
                slideRight(table[2,3]);
                slideRight(table[3,3]);
                putRandomValues();
                drawTable();
                ClearHC();
                Console.WriteLine("\n");  
                slideUp(table[0,0]);
                slideUp(table[0,1]);
                slideUp(table[0,2]);
                slideUp(table[0,3]);
                putRandomValues();
                drawTable();
                ClearHC();
                Console.WriteLine("\n");  
                slideDown(table[3,0]);
                slideDown(table[3,1]);
                slideDown(table[3,2]);
                slideDown(table[3,3]);
                putRandomValues();
                drawTable();
                ClearHC();


    }

    public void UpPressed()
    {
        
        int coll = this.coll ;
        for(int j = 0 ; j<coll; j++)
        {
            slideUp(table[1,j]);
        }
    }

    public void DownPressed()
    {
        int row = this.row - 2 ;
        int coll = this.coll ; 
        for(int j = 0; j< coll ; j++)
        {
            slideDown(table[row,j]);
        }
    }

    public void LeftPressed()
    {
        int row = this.row ;
        for (int i = 0; i<row;i ++)
        {
            slideLeft(table[i,1]);
        }
    }

    public void RightPressed()
    {
        int row = this.row ;
        int coll = this.coll-2 ;
        for (int i =0 ; i<row ;i++)
        {
            slideRight(table[i,coll]);
        }
    }

    public bool isGameOver()
    {
        int row = table.GetUpperBound(0) + 1 ;
        int coll = table.GetUpperBound(1) + 1 ;
        for (int i =0 ; i <row ; i++)
        {
            for (int j= 0 ; j<row ; j++)
            {
                if(table[i,j].value == 0) return false ;
            }
        }
        return true ;
    }


}
    class Program
    {   
         
       public static void Main(string[] args)
        {
            
            Game2048 game = new Game2048(4,4);
            game.StartGame() ;
            
            /*do {
                
                input = Console.ReadKey(true) ;
                if (input.Key.ToString() == "Spacebar")
                {
                    if (input.Key.ToString() == "W")
                    {
                        
                    }
                }


            }while (input.Key != ConsoleKey.Escape && !isOver) ;*/
            
        }

        
    }

   
}
