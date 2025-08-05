using System.Security.Cryptography;

namespace MeuBackEndApi.Src.Utils
{
    public static class SenhaConverter
    {
        public static string HashPassword(string password)
        {
            // Gerar um salt aleatório
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Gerar hash usando PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32); // 256 bits

            // Combinar salt + hash para armazenar
            byte[] hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            // Converter para base64 para armazenar no banco
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            // Converter base64 para bytes
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Pegar o salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Gerar o hash com a senha fornecida e o salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Comparar o hash gerado com o hash armazenado
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }
}
