using Microsoft.Data.Sqlite;
using Avaliacao3BimLp3.Database;
using Avaliacao3BimLp3.Repositories;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);

var productRepositorie = new ProductRepositorie(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName =="Product"){

   if(modelAction == "List")
    {   // any() está conferindo se a lista está vazia
        if(productRepositorie.GetAll().Any())
        {
            foreach(var product in productRepositorie.GetAll())
            {
                Console.WriteLine($" {product.Id}, {product.Name}, {product.Price}, {product.Active}");
            }
        }
        
    }

    if(modelAction =="New")
    {
       
        int id = Convert.ToInt32(args[2]);
        string name = args [3];
        double price = Convert.ToDouble(args[4]);
        bool active = Convert.ToBoolean(args[5]);


        var product = new Product(id, name, price, active);
     
    }

     if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);
        if(productRepositorie.ExitsById(id))
        {
            productRepositorie.Delete(id);
        }
        else
        {
            Console.WriteLine($"O Produto {id} não existe.");
        }        
    }

    if(modelAction == "Enable")
    {
        var id = Convert.ToInt32(args[2]);
        if(productRepositorie.ExitsById(id))
        {
            productRepositorie.Enable(id);
            Console.WriteLine($"Produto {id} adicionado ");
        }
      
    }

    if(modelAction == "Disable")
    {
        var id = Convert.ToInt32(args[2]);
        if(productRepositorie.ExitsById(id))
        {
            productRepositorie.Disable(id);
            Console.WriteLine($"Produto {id} não existente");
        }
       
    }

     if(modelAction == "PriceBetween")
    {
        var initialPrice = Convert.ToDouble(args[2]);
        var endPrice = Convert.ToDouble(args[3]);

        if(productRepositorie.GetAllWithPriceBetween(initialPrice,endPrice).Any())
        {
            foreach(var product in productRepositorie.GetAllWithPriceBetween(initialPrice,endPrice))
            {
                Console.WriteLine($" {product.Id}, {product.Name}, {product.Price}, {product.Active}");
            }
        }
        
    }

    if(modelAction == "PriceHigherThan")
    {   
        var price = Convert.ToDouble(args[2]);
        
        if(productRepositorie.GetAllWithPriceHigherThan(price).Any())
        {
            foreach(var product in productRepositorie.GetAllWithPriceHigherThan(price))
            {
                Console.WriteLine($" {product.Id}, {product.Name}, {product.Price}, {product.Active}");
            }
        }
       

    }

    if(modelAction == "PriceLowerThan")
    {   
        var price = Convert.ToDouble(args[2]);
        
        if(productRepositorie.GetAllWithPriceLowerThan(price).Any())
        {
            foreach(var product in productRepositorie.GetAllWithPriceLowerThan(price))
            {
                Console.WriteLine($" {product.Id}, {product.Name}, {product.Price}, {product.Active}");
            }
        }
       
    }

    if(modelAction == "AveragePrice")
    {
        if(productRepositorie.GetAll().Any())
        {
            Console.WriteLine($"O valor médio dos preços é de R$ {productRepositorie.GetAveragePrice()}");
        }
        
    }

}