using Gym_Booking_Manager;
using static Gym_Booking_Manager.Space;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;



namespace Gym_Booking_Manager.Tests
{
    [TestClass]
    public class SpaceTests
    {
        [TestMethod]
        public void Constructor_WithDictionary_ShouldCreateSpaceObject()
        {
            // Arrange
            var constructionArgs = new Dictionary<string, string>
            {
                { "category", "hall" },
                { "uniqueID", "1" },
                { "isRestricted", "true" }
            };

            // Act
            var space = new Space(constructionArgs);

            // Assert
            Assert.AreEqual(Space.Category.hall, space.category);
            Assert.AreEqual(1, space.uniqueID);
            Assert.IsTrue(space.isRestricted);
        }

        [TestMethod]
        public void ToString_ShouldReturnFormattedString()
        {
            // Arrange
            var space = new Space(1, Space.Category.lane, false);

            // Act
            var result = space.ToString();

            // Assert
            Assert.AreEqual("uniqueID:1,category:lane,isRestricted:False", result);
        }

        [TestMethod]
        public void CSVify_ShouldReturnFormattedString()
        {
            // Arrange
            var space = new Space(1, Space.Category.studio, true);

            // Act
            var result = space.CSVify();

            // Assert
            Assert.AreEqual("uniqueID:1,category:studio,isRestricted:True", result);
        }
    }
}