using System;

namespace _538_problem
{
    class Coin
    {
        // This coin state can be private because the methods (which are public) provide all access to this info.
        private string state;

        public Coin()
        {
             // This is a CONSTRUCTOR for new coin objects.

             Random rnd = new Random();
             
             // This SHOULD set the status to heads or tails each about 50% of the time.  verify.
             if (rnd.Next(2) == 0)
             {
                 state = "Tails";
             }
             else
             {
                 state = "Heads";
             }
        }

        public void Display()
        {
            Console.WriteLine("Coin state is " + state);
        }
        
        public string GetStatus()
        {
            return (state);
        }

        public void Flip()
        {
            if (this.state == "Tails") 
            {
                state = "Heads";
            }
            else 
            {
                state = "Tails";
            }
        }
    }
}
