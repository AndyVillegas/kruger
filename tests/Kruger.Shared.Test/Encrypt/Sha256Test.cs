using Kruger.Shared.Encrypt;
using Xunit;

namespace Kruger.Shared.Test.Encrypt
{
    public class Sha256Test
    {
        [Fact]
        public void Test_Encrypt_A_Text()
        {
            var textToEncrypt = "admin";
            var expectedResult = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";
            var result = Sha256.Encrypt(textToEncrypt);
            Assert.Equal(expectedResult, result);
        }
    }
}
