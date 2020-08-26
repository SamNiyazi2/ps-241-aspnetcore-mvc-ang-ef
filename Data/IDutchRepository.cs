using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// 08/25/2020 07:56 am - SSN - [20200825-0749] - [002] - M07-07 - The repository pattern

namespace ps_DutchTreat.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsyCategory(string category);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}