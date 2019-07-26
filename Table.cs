using System;

namespace _538_problem
{
    class Table
    {
        // The internal data struture of this object is a 2 by 2 matrix of coins. 
        private Coin[,] CoinArray = new Coin[2,2];

        public Table()
        {
            // Table object Constructor
            CoinArray[0,0] = new Coin();
            CoinArray[0,1] = new Coin();
            CoinArray[1,0] = new Coin();
            CoinArray[1,1] = new Coin();
        }

        public void PrintState()
        {
            Console.WriteLine(CoinArray[0,0].GetStatus() + " " + CoinArray[0,1].GetStatus());
            Console.WriteLine(CoinArray[1,0].GetStatus() + " " + CoinArray[1,1].GetStatus());
        }

        public void RotateClockwise(string rotationCount)
        {
            if (rotationCount != "random")
            {
                throw new System.ArgumentException("only 'random' implemented");
            }
            Random rnd = new Random();
            RotateClockwise(rnd.Next(5));
        }

        public void RotateClockwise(int rotationCount)
        {
            // This didn't work because it was pass by REFERENCE and changes overwrote the value i needed!
            // Coin[,] beforeState = CoinArray;
            Coin topLeftBackup = CoinArray[0,0];
            Coin topRightBackup = CoinArray[0,1];
 
            switch (rotationCount % 4)
            {
                case 0:
                    // multiples of four rotations are the same as no rotations.  Nothing to do.
                    break;
                
                case 1:
                    CoinArray[0,0] = CoinArray[1,0];
                    CoinArray[1,0] = CoinArray[1,1];
                    CoinArray[1,1] = CoinArray[0,1];
                    CoinArray[0,1] = topLeftBackup;
                    break;
                
                case 2:
                    // 2 (or 6 or 10) rotations.  We need to use both backed-up values.
                    CoinArray[0,0] = CoinArray[1,1];
                    CoinArray[1,1] = topLeftBackup;
                    CoinArray[0,1] = CoinArray[1,0];
                    CoinArray[1,0] = topRightBackup;
                    break;
                
                case 3:
                    // 3 (or 7, or 11, etc) clockwise rotations is the same as 1 counter-clockwise rotation.
                    CoinArray[0,0] = CoinArray[0,1];
                    CoinArray[0,1] = CoinArray[1,1];
                    CoinArray[1,1] = CoinArray[1,0];
                    CoinArray[1,0] = topLeftBackup;
                    break;
            }
        }

        public void Flipcoin(bool topLeft, bool topRight, bool bottomLeft, bool bottomRight)
        {
            if (topLeft)
            {
                CoinArray[0, 0].Flip();
            }
            if (topRight)
            {
                CoinArray[0, 1].Flip();
            }
            if (bottomLeft)
            {
                CoinArray[1, 0].Flip();
            }
            if (bottomRight)
            {
                CoinArray[1, 1].Flip();
            }
        }

        private bool GetRandomBool()
        {
            Random rnd = new Random();
            Boolean result;

            if (rnd.Next(2) == 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
            
        public void FlipRandomCoins()
        {
            Flipcoin(GetRandomBool(), GetRandomBool(), GetRandomBool(), GetRandomBool());
        }
    
        public bool GetVictoryStatus()
        {
            // if all four coins are heads, the game is won and we return TRUE.  If not, FALSE.
            return (CoinArray[0,0].GetStatus() == "Heads" &&
                    CoinArray[0,1].GetStatus() == "Heads" &&
                    CoinArray[1,0].GetStatus() == "Heads" &&
                    CoinArray[1,1].GetStatus() == "Heads");
        }
    }
}
