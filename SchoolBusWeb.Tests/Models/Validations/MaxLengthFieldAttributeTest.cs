using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Tests.Models.Validations
{
    [TestClass]
    public class MaxLengthFieldAttributeTest
    {
        [TestMethod]
        public void MaxLengthFieldAttributeInitTest()
        {
            /*Arrange*/
            const int expectedLength = 200;
            const string expectedFieldName = "TestFieldName";
            var expectedErrorMessage = string.Format("{0} excede la longitud de {1} caracteres.", expectedFieldName, expectedLength);

            /*Act*/
            var actualAttribute = new MaxLengthFieldAttribute(expectedLength, expectedFieldName);

            /*Assert*/
            Assert.AreEqual(expectedLength, actualAttribute.Length);
            Assert.AreEqual(expectedFieldName, actualAttribute.FieldName);
            Assert.AreEqual(expectedErrorMessage, actualAttribute.ErrorMessage);
        }
    }
}