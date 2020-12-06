﻿using InventoryDAL.Products;
using InventoryDAL.ProductTag;
using InventoryLogic.Interfaces;
using InventoryLogic.Products;
using InventoryLogic.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using InventoryDAL.Factories.Interfaces;
using InventoryDAL.Products.PropertyProducts;
using InventoryDAL.Products.PropertyProducts.Interfaces;

namespace InventoryDAL.Tags
{
    public class TagBuilder : ITagBuilder
    {
        private readonly IDomainFactory domainFactory;
        private readonly IPropertyProductSupplier propertyProductSupplier;
        private readonly ITagEntity tagEntity;


        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public TagBuilder(ITagEntity tagEntity, IDomainFactory domainFactory, IPropertyProductSupplier propertyProductSupplier)
        {
            this.domainFactory = domainFactory;
            this.propertyProductSupplier = propertyProductSupplier;
            this.tagEntity = tagEntity;

            this.Id = tagEntity.Id;
            this.Name = tagEntity.Name;
            this.Products = new List<Product>();
        }

        public void BuildProducts()
        {
            IList<ProductTagEntity> productTagEntities = tagEntity.ProductTagEntities;
            if (productTagEntities == null) return;
            List<Product> products = new List<Product>();
            foreach (var prodTag in productTagEntities)
            {
                Product product = GetProduct(prodTag);
                products.Add(product);
            }
            this.Products = products;
        }

        private Product GetProduct(ProductTagEntity prodTag)
        {
            try
            {
                return propertyProductSupplier.Get(prodTag.ProductId);
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Product not found. Please first create the product.", e);
            }
        }

        public Tag GetResult()
        {
            return domainFactory.CreateTag(Id, Name, Products);
        }
    }
}