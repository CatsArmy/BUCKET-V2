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

        public Bucket(int capacity)
        {
            this.capacity = capacity;
            this.currentAmount = 0;
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
            if (this.capacity < this.currentAmount + amountToFill)
                this.currentAmount = this.capacity;
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
        public override string ToString()
        {
            return $@"The capacity is : {this.capacity}
The current amount is : {this.currentAmount};";
        }
    }
}
