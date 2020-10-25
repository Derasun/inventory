﻿using System.Collections.Generic;

namespace InventoryLogic.Products
{
    public interface IProductDAO
    {
        Product Get(int ID);
        List<Product> GetAll();
        void Add(Product product);
        void Remove(int ID);
        void Modify(Product product);
    }
}