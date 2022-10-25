List<string> shoppingList = new List<string>();
List<decimal> itemTotal = new List<decimal>();

Dictionary<string, decimal> foodList = new Dictionary<string, decimal>()
{
    {"Beer", 6.00m},
    {"Bread", 2.00m},
    {"Butter", 1.00m},
    {"Chicken", 5.50m},
    {"Eggs", 3.00m},
    {"Hamburger", 6.00m},
    {"Juice", 5.50m},
    {"Milk", 4.00m}
};

Console.WriteLine($"Welcome to After Hours Food Mart!{Environment.NewLine}");

bool addItem = true;

while (addItem)
{
    foreach (var food in foodList)
    {
        var index = foodList.ToList().IndexOf(food);
        Console.WriteLine($"{food.Key} and cost is ${food.Value}!");
    }


    Console.WriteLine($"Please enter and Item you would like to add to your shopping list!");
    string shoppingItem = Console.ReadLine()!.ToLower().Trim().Replace(" ", "");
    bool isValid = ValidItem(shoppingItem);

    if (isValid)
    {
        shoppingList.Add(shoppingItem);
        shoppingList.Sort();
        Console.WriteLine("Would you like to add another item type y or n to get your total!");
        addItem = Console.ReadLine()!.ToLower().Trim() == "y";
    }
    else
    {
        Console.WriteLine($"You did not enter a valid item {shoppingItem} {Environment.NewLine}");
        Console.WriteLine("Would you like to add another item type y or n to get your total!");
        addItem = Console.ReadLine()!.ToLower().Trim() == "y";
    }
}


if (!addItem)
{
    foreach (var item in shoppingList)
    {
        IEnumerable<decimal> itemCost = foodList.Where(kv => kv.Key.ToLower().Contains(item)).Select(x => x.Value);
        Console.WriteLine($"You have {item} in your cart your cost is ${itemCost.FirstOrDefault()}");
        itemTotal.Add(itemCost.FirstOrDefault());
    }

    decimal orderTotal = itemTotal.Sum();
    Console.WriteLine($"Your order total is ${orderTotal}");
}


bool ValidItem(string shoppingItem)
{
    switch (shoppingItem)
    {
        case "chicken":
            return true;

        case "hamburger":
            return true;


        case "bread":
            return true;


        case "butter":
            return true;


        case "eggs":
            return true;


        case "milk":
            return true;


        case "juice":
            return true;


        case "beer":
            return true;
    }

    return false;
}