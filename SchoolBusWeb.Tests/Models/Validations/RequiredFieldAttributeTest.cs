using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolBusWeb.Models.Validations;

namespace SchoolBusWeb.Tests.Models.Validations
{
    [TestClass]
    public class RequiredFieldAttributeTest
    {
        [TestMethod]
        public void RequiredFieldAttributeInitTest()
        {
            /*Arrange*/
            const string expectedFieldName = "TestFieldName";
            var expectedErrorMessage = string.Format("{0} es requerido.", expectedFieldName);

            /*Act*/
            var actualAttribute = new RequiredFieldAttribute(expectedFieldName);

            /*Assert*/
            Assert.AreEqual(expectedFieldName, actualAttribute.FieldName);
            Assert.AreEqual(expectedErrorMessage, actualAttribute.ErrorMessage);
        }
    }
}