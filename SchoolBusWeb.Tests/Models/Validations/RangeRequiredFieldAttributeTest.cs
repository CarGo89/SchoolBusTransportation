using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Tests.Models.Validations
{
    [TestClass]
    public class RangeRequiredFieldAttributeTest
    {
        [TestMethod]
        public void RangeRequiredFieldAttributeInitIntTest()
        {
            /*Arrange*/
            const int expectedMin = 1;
            const int expectedMax = 10;
            const string expectedFieldName = "TestFieldName";
            var expectedErrorMessage = string.Format("{0} es requerido.", expectedFieldName);

            /*Act*/
            var actualAttribute = new RangeRequiredFieldAttribute(expectedMin, expectedMax, expectedFieldName);

            /*Assert*/
            Assert.AreEqual(expectedMin, actualAttribute.Minimum);
            Assert.AreEqual(expectedMax, actualAttribute.Maximum);
            Assert.AreEqual(expectedFieldName, actualAttribute.FieldName);
            Assert.AreEqual(expectedErrorMessage, actualAttribute.ErrorMessage);
        }

        [TestMethod]
        public void RangeRequiredFieldAttributeInitDoubleTest()
        {
            /*Arrange*/
            const double expectedMin = 1;
            const double expectedMax = 10;
            const string expectedFieldName = "TestFieldName";
            var expectedErrorMessage = string.Format("{0} es requerido.", expectedFieldName);

            /*Act*/
            var actualAttribute = new RangeRequiredFieldAttribute(expectedMin, expectedMax, expectedFieldName);

            /*Assert*/
            Assert.AreEqual(expectedMin, actualAttribute.Minimum);
            Assert.AreEqual(expectedMax, actualAttribute.Maximum);
            Assert.AreEqual(expectedFieldName, actualAttribute.FieldName);
            Assert.AreEqual(expectedErrorMessage, actualAttribute.ErrorMessage);
        }

        [TestMethod]
        public void RangeRequiredFieldAttributeInitTypeTest()
        {
            /*Arrange*/
            const string expectedMin = "1";
            const string expectedMax = "10";
            const string expectedFieldName = "TestFieldName";
            var expectedType = typeof(string);
            var expectedErrorMessage = string.Format("{0} es requerido.", expectedFieldName);

            /*Act*/
            var actualAttribute = new RangeRequiredFieldAttribute(expectedType, expectedMin, expectedMax, expectedFieldName);

            /*Assert*/
            Assert.AreEqual(expectedType, actualAttribute.OperandType);
            Assert.AreEqual(expectedMin, actualAttribute.Minimum);
            Assert.AreEqual(expectedMax, actualAttribute.Maximum);
            Assert.AreEqual(expectedFieldName, actualAttribute.FieldName);
            Assert.AreEqual(expectedErrorMessage, actualAttribute.ErrorMessage);
        }
    }
}