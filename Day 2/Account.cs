public class Account
    {
        public decimal Balance { get; protected set; }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance.");
            }
        }
    }

    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        // Override the Withdraw method to add fee to the amount, but do not change its original behavior
        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                amount += 5.0m; // Add the fee
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance.");
            }
        }
    }