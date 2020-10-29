﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryLogic.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using InventoryLogic.ProductTagJoins;

namespace InventoryLogic.Tags.Tests
{
    [TestClass()]
    public class TagTests
    {
        [TestMethod()]
        public void CreateTag()
        {
            Tag tag = new Tag();
        }

        [TestMethod()]
        public void ConstructTagWithParameterName()
        {
            string expected = "TestTag";

            Tag tag = new Tag(1, expected);
            string actual = tag.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConstructTagWithParameterId()
        {
            int expected = 1;

            Tag tag = new Tag(expected, "TestTag");
            int actual = tag.Id;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNameShouldReturnNull()
        {
            Tag tag = new Tag();
            string expected = null;

            string actual = tag.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNameShouldReturnSetName()
        {
            Tag tag = new Tag();
            string expected = "name";

            tag.Name = expected;
            string actual = tag.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetIdShouldReturnSetId()
        {
            Tag tag = new Tag();
            int expected = 245;

            tag.Id = expected;
            int actual = tag.Id;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetProductTagJoinsShouldReturnProductTagJoins()
        {
            var mock = new Mock<ProductTagJoin>();
            mock.Setup(j => j.ProductId).Returns(1);
            var mockProduct = mock.Object;
            Tag tag = new Tag();

            tag.ProductTagJoins.Add(mockProduct);
            var actual = tag.ProductTagJoins[0];

            Assert.AreEqual(mockProduct, actual);
        }
    }
}