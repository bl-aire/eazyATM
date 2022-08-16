using System;

public class cardHolder
{
    string cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    //constructor
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //getters
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

    //setters
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(String[] args)
    {
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
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance() + deposit);
        }

        void withdraw (cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if user has enough money so they don't withdraw more than what is available
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you! You are good to go");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        //Default list of card holders(mock database)
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532 5647 7564 6565", 1234, "Enenche", "Okpeh", 1000.00));
        cardHolders.Add(new cardHolder("1234 5678 9101 1121", 4321, "Jaden", "John", 100.54));
        cardHolders.Add(new cardHolder("6765 7687 6765 9898", 6666, "Scott", "Jones", 43.33));
        cardHolders.Add(new cardHolder("4432 5644 6755 8987", 2468, "Ade", "Prince", 865.22));
        cardHolders.Add(new cardHolder("8898 9999 6564 2345", 6969, "Adaora", "Chioma", 54.23));

        //Prompt user

        Console.WriteLine("Welcome to BlaireATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser  != null){ break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }  
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check against database
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day " + currentUser.getFirstName() + ":)");

    }
}