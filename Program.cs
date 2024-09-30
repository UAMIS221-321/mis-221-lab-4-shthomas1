// Main

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

string menuSelection = "";
while (menuSelection != "2"){
    MainMenu();
    menuSelection = GetMenuSelection();
    RouteMenu(menuSelection);
}

// End Main

static void MainMenu(){
    Console.Clear();
    System.Console.WriteLine("Main Menu\n\t1. Order a Pizza\n\t2. Exit the Application");
}

static string GetMenuSelection(){
    return Console.ReadLine();
}

static void RouteMenu(string menuSelection){
    switch(menuSelection){
        case "1":
            DisplayOrder();
            string pizzaSelection = GetMenuSelection();
            RouteOrder(pizzaSelection);
            break;

        case "2":
            break;

        default:
            DisplayError();
            Pause();
            break;
    }
}

static void DisplayOrder(){
    Console.Clear();
    System.Console.WriteLine("What kind of Pizza would you like?\n\t1. Plain\n\t2. Cheese\n\t3. Pepperoni\n\t4. Exit");
}

static void RouteOrder(string pizzaSelection){
    switch(pizzaSelection){
        case "1":
            PlainPizza();
            Pause();
            break;

        case "2":
            CheesePizza();
            Pause();
            break;

        case "3":
            PepPizza();
            Pause();
            break;

        case "4":
            break;

        default:
            DisplayError();
            Pause();
            break;
    }
}

static void PlainPizza(){
    System.Console.WriteLine("Input how long you would like the edge of your pizza to be.");                //I did this so that the pizza can be any size.
    int length = int.Parse(Console.ReadLine());
    
    for (int i = length; i > 0; i--){
        for (int j = 0; j < i; j++){
            Console.Write("*\t");
        }
        Console.WriteLine();
    }
}

static void CheesePizza(){
    System.Console.WriteLine("Input how long you would like the edge of your pizza to be.");                //Size selection
    int length = int.Parse(Console.ReadLine());

    for (int i = length; i > 0; i--){
        for (int j = 0; j < i; j++){
            if (j == 0 || j == i -1 || i == length)
            Console.Write("*\t");
            else
                Console.Write("#\t");                     //TAhis was pretty much done in class. The if/else statement is a function that prints a * if the location is along the edge of the pizza, and a # if it is in the middle
        }
        Console.WriteLine();
    }
}

static void PepPizza(){
    System.Console.WriteLine("Input how long you would like the edge of your pizza to be.");                //Size selection
    int length = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Input the density of pepperoni you would like. 1 = 100%, 2 = 50%, 3 = 33% and so on.");
    int density = int.Parse(Console.ReadLine());

    Random rand = new Random();

    for (int i = length; i > 0; i--){
        for (int j = 0; j < i; j++){
            if (j == 0 || j == i -1 || i == length)
            Console.Write("*\t");
            else
                if (rand.Next(0,density) == 0)
                    Console.Write("[]\t");                //Generates a random number, if 0 then prints [] Density of pepperoni is a variable of how many they would like on average
                else
                    Console.Write("#\t");                 //Prints the cheese everywhere else outside of edges
        }
        Console.WriteLine();                            //Moves to next line
    }
}

static void DisplayError(){
    System.Console.WriteLine("Invalid Menu Selection. Routing to main menu. Please try again...");
}

static void Pause(){
    System.Console.WriteLine("\tPress any key to Continue...");
    Console.ReadKey();
}
