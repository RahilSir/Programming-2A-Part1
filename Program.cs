using System;
using System.Collections.Generic;

class Ingredient
{
    //name of ingredient
    public string Name { get; set; }
// quantity of ingredient
    public double Quantity { get; set; }
    //units of the quantity 
    public string Unit { get; set; }
}

class Step
{
    // descciption of the steps
    public string Description { get; set; }
}

class Recipe
{
    public List<Ingredient> Ingredients { get; set; }
    public List<Step> Steps { get; set; }

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<Step>();
    }
}

class Program
{
    static void Main()
    {
        Recipe recipe = new Recipe();

        Console.WriteLine("Enter the details for your recipe:");

        Console.Write("Enter the number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());

// loop to get details of each ingredient

        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Enter details for ingredient {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            double quantity = double.Parse(Console.ReadLine());
            Console.Write("Unit: ");
            string unit = Console.ReadLine();

            recipe.Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit });
        }
// enter number of steps


        Console.Write("Enter the number of steps: ");
        int numSteps = int.Parse(Console.ReadLine());

        for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"Enter step {i + 1}:");
            string description = Console.ReadLine();

            recipe.Steps.Add(new Step { Description = description });
        }

        DisplayRecipe(recipe);

        // Scaling the recipe
        Console.WriteLine("\nDo you want to scale the recipe? (Enter 0.5, 2, 3, or N for no)");
        string scaleInput = Console.ReadLine();

        if (double.TryParse(scaleInput, out double scale) && (scale == 0.5 || scale == 2 || scale == 3))
        {
            ScaleRecipe(recipe, scale);
            DisplayRecipe(recipe);
        }
        else if (scaleInput.ToUpper() == "N")
        {
            Console.WriteLine("Recipe is not scaled.");
        }
        else
        {
            Console.WriteLine("Invalid input. Recipe is not scaled.");
        }

        Console.ReadLine();
    }
// diplay the recipe 
    static void DisplayRecipe(Recipe recipe)
    {
        Console.WriteLine("\nRecipe:");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in recipe.Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < recipe.Steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipe.Steps[i].Description}");
        }
    }

    static void ScaleRecipe(Recipe recipe, double scale)
    {
        foreach (var ingredient in recipe.Ingredients)
        {
            ingredient.Quantity *= scale;
        }
    }
}

