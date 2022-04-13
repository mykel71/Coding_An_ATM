using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public string getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastname)
    {
        lastName = newLastname;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    //Main Method to run the ATM
    public static void Main(string[] args)
    {
        //In Here will define a few functions that will help us later

        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if the user has enough money

            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank You :");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }
        // Creating a new List of people

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1234567891", 1234, "Michael", "Munemo", 90000.31));
        cardHolders.Add(new cardHolder("987654321", 4561, "Mael", "Asah", 200.65));
        cardHolders.Add(new cardHolder("741852963", 1230, "Zoe", "Naomi", 335.31));
        cardHolders.Add(new cardHolder("852963741", 1470, "Nathan", "Leigh", 785.01));
        cardHolders.Add(new cardHolder("123456789", 8521, "Shalom", "Shaddai", 7000.31));

        // Prompt user
        Console.WriteLine("Welcome to MykelATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) 
                { 
                    break; 
                }
                else 
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }
        Console.WriteLine("Please enter your Pin: "); 
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check against our db
               // currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser.getPin() == userPin)
                {
                    break ;
                }
                else
                {
                    Console.WriteLine("Incorrect Pin. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }
            if(option == 1)
            {
                deposit(currentUser);
            }
            else if(option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if(option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }
        }
        while (option != 4);
        Console.WriteLine("Thank You! Have a nice day :)");
    }

}