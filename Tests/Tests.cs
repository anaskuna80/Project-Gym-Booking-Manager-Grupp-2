using System.Collections.Generic;
using Gym_Booking_Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gym_Booking_Manager_Tests
{
    [TestClass]
    public class GroupActivityTests
    {
        [TestMethod]
        public void SignUp_AddsParticipantToList()
        {
            // Arrange
            var groupActivity = new GroupActivity("Test Activity", 10, "Test Instructor", 1);

            // Act
            groupActivity.SignUp(1);

            // Assert
            Assert.AreEqual(1, groupActivity.participants.Count);
            Assert.AreEqual(1, groupActivity.participants[0]);
        }

        [TestMethod]
        public void SignUp_WhenActivityIsFull_DoesNotAddParticipantToList()
        {
            // Arrange
            var groupActivity = new GroupActivity("Test Activity", 2, "Test Instructor", 1);
            groupActivity.SignUp(1);
            groupActivity.SignUp(2);

            // Act
            groupActivity.SignUp(3);

            // Assert
            Assert.AreEqual(2, groupActivity.participants.Count);
            Assert.IsFalse(groupActivity.participants.Contains(3));
        }

        

        [TestMethod]
        public void CompareTo_WhenOtherIsNull_Returns1()
        {
            // Arrange
            var groupActivity1 = new GroupActivity("Activity 1", 10, "Instructor 1", 1);
            GroupActivity groupActivity2 = null;

            // Act
            var result = groupActivity1.CompareTo(groupActivity2);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareTo_WhenOtherIsLess_ReturnsNegativeValue()
        {
            // Arrange
            var groupActivity1 = new GroupActivity("Activity 1", 10, "Instructor 1", 1);
            var groupActivity2 = new GroupActivity("Activity 2", 10, "Instructor 2", 2);

            // Act
            var result = groupActivity1.CompareTo(groupActivity2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_WhenOtherIsGreater_ReturnsPositiveValue()
        {
            // Arrange
            var groupActivity1 = new GroupActivity("Activity 1", 10, "Instructor 1", 1);
            var groupActivity2 = new GroupActivity("Activity 2", 10, "Instructor 2", 2);

            // Act
            var result = groupActivity2.CompareTo(groupActivity1);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_WhenOtherIsEqual_ReturnsZero()
        {
            // Arrange
            var groupActivity1 = new GroupActivity("Activity 1", 10, "Instructor 1", 1);
            var groupActivity2 = new GroupActivity("Activity 2", 10, "Instructor 2", 1);

            // Act
            var result = groupActivity1.CompareTo(groupActivity2);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}