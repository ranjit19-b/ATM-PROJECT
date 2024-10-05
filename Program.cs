using System;
public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
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

    public void setNum(String newcardNum)
    {
        cardNum = newcardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newfirstName)
    {
        firstName = newfirstName;
    }

    public void setLastName(String newlastName)
    {
        lastName = newlastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            double withdrawl = Double.Parse(Console.ReadLine());
            //check if the user has enough money 
            if (currentUser.getBalance() > withdrawl)
            {
                Console.WriteLine("Insufficient balance ");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("You are good to go! Thank you: ");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("current balance: " + currentUser.getBalance);
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1234567890123456", 1234, "Ranjit", "Kumar", 150.31));
        cardHolders.Add(new cardHolder("1234567890123457", 1235, "Sandeep", "Kumar", 150.31));
        cardHolders.Add(new cardHolder("1234567890123458", 1236, "Rohit", "Kumar", 150.31));
        cardHolders.Add(new cardHolder("1234567890123459", 1237, "Pooja", "Kumari", 150.31));
        cardHolders.Add(new cardHolder("1234567890123450", 1238, "Charvik", "Kumar", 150.31));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card:");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recoganized.Please try again"); }
            }
            catch { Console.WriteLine("Card not recoganized.Please try again"); }
        }

        Console.WriteLine("Please enteer your pin:");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                currentUser = cardHolders.FirstOrDefault(a => a.pin == userPin);   
                if(currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin.Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin.Please try again"); }
        }
        Console.WriteLine("Welcome" + currentUser.getFirstName() + " :)");
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
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :");
    }

}   