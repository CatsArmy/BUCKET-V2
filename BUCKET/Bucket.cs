using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUCKET
{
    public class Bucket
    {
        private int capacity;
        private double currentAmount;
        /* Before Q2 
         * public Bucket(int capacity)
         {
             this.capacity = capacity;
             this.currentAmount = 0;
         }*/
        public Bucket(int capacity, double currentAmount = 0)
        {
            this.capacity = capacity;
            this.currentAmount = currentAmount;
        }
        public void Empty()
        {
            this.currentAmount = 0;
        }
        public bool IsEmpty()
        {
            return this.currentAmount == 0;
        }
        public void Fill(double amountToFill = 0)
        {
            /* before Q3
             * if (this.capacity < this.currentAmount + amountToFill)
                this.currentAmount = this.capacity;
            else
                this.currentAmount += amountToFill;*/
            if (this.capacity == this.currentAmount && amountToFill > 0)
            {
                Console.WriteLine($@"The Bucket was Full... But the water kept coming.
The Bucket began to spill out water equivalent to {amountToFill}
Why did you even try to fill the bucket if it was full...");
            }
            else if (this.capacity < this.currentAmount + amountToFill)
            {
                int i = 0;
                amountToFill += currentAmount;
                while (amountToFill > this.capacity) {
                    amountToFill -= this.capacity;
                    i++;
                }
                
                if (i > 0) 
                {
                    if (amountToFill < 0 && amountToFill < capacity) { amountToFill *= -1; }
                    if (amountToFill > 0 && amountToFill < capacity) {
                        Console.WriteLine($@"The Bucket Fills all the way but the water keeps coming.
The Bucket begins to spill out the equivalent to {capacity * i - amountToFill} of water"); }
                    else {
                    Console.WriteLine($@"The Bucket Fills all the way but the water keeps coming.
The Bucket begins to spill out the equivalent to {capacity * i} of water"); }
                    }
                this.currentAmount = this.capacity;
            }
            else
                this.currentAmount += amountToFill;
        }
        public int GetCapacity()
        {
            return this.capacity;
        }
        public double GetCurrentAmount()
        {
            return this.currentAmount;
        }
        public void FourInto(Bucket bucketInto)
        {
            double freespace = bucketInto.GetCapacity() -
                bucketInto.GetCurrentAmount();
            if (this.currentAmount < freespace)
            {
                bucketInto.Fill(this.currentAmount);
                this.currentAmount = 0;
            }
            else
            {
                bucketInto.Fill(freespace);
                this.currentAmount -= freespace;
            }
        }
        public void FillAll() //+added by question4.1
        {
            if (this.currentAmount == this.capacity)
            {
                Console.WriteLine("but why would you do this");
            }
            this.currentAmount = this.capacity;
        }
        public bool IsFull()
        {
            return  this.currentAmount >= this.capacity;
        }
        public override string ToString()
        {
            return $@"The capacity is : {this.capacity}
The current amount is : {this.currentAmount};";
        }
    }
}
