using System.Text;

namespace FileReaderLib.Encryption.Tests
{
    [TestClass()]
    public class EncryptionStrategyTests
    {
        [TestMethod()]
        public void AesEncryptionStrategyTest1()
        {
            string input = "Hello, this is a test."; 
            AesEncryptionStrategy encryptionStrategy = new ();

            // Encrypt and decrypt input
            byte[] encryptedInput = encryptionStrategy.Encrypt(Encoding.UTF8.GetBytes(input));
            byte[] decryptedInput = encryptionStrategy.Decrypt(encryptedInput);

            // Assert original and read values are the same. 
            Assert.AreEqual(input, Encoding.UTF8.GetString(decryptedInput));
            Assert.AreNotEqual(input, Encoding.UTF8.GetString(encryptedInput));
        }
        [TestMethod()]
        public void AesEncryptionStrategyTest2()
        {
            int input = 50_956_420;
            AesEncryptionStrategy encryptionStrategy = new ();

            // Encrypt and decrypt input
            byte[] encryptedInput = encryptionStrategy.Encrypt(BitConverter.GetBytes(input));
            byte[] decryptedInput = encryptionStrategy.Decrypt(encryptedInput);

            // Assert original and read values are the same. 
            Assert.AreEqual(input, BitConverter.ToInt32(decryptedInput));
            Assert.AreNotEqual(input, BitConverter.ToInt32(encryptedInput));
        }
        [TestMethod()]
        public void ReverseEncryptionStrategyTest1()
        {
            int input = 50_956_420;
            ReverseEncryptionStrategy encryptionStrategy = new();

            // Encrypt and decrypt input
            byte[] encryptedInput = encryptionStrategy.Encrypt(BitConverter.GetBytes(input));
            byte[] decryptedInput = encryptionStrategy.Decrypt(encryptedInput);

            // Assert original and read values are the same. 
            Assert.AreEqual(input, BitConverter.ToInt32(decryptedInput));
            Assert.AreNotEqual(input, BitConverter.ToInt32(encryptedInput));
        }
    }
}
