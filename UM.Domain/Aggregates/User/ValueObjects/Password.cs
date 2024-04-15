using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using UM.Domain.Aggregates.User.Errors;

namespace UM.Domain.Aggregates.User.ValueObjects
{
    public class Password : ValueObject
    {
        private const int MimLength = 3;
        private const int MaxLength = 20;

        public string Salt { get; } = string.Empty;
        public string Hash { get; } = string.Empty;

        private Password(string salt, string hash)
        {
            Salt = salt;
            Hash = hash;
        }

        public static Result<Password> Create(string password)
        {
            if (!IsPasswordValid(password))
                return Result.Failure(new InvalidPasswordLengthError(MimLength, MaxLength));

            var saltBytes = RandomNumberGenerator.GetBytes(16);

            var salt = Convert.ToBase64String(saltBytes);
            var hash = GetHash(saltBytes, password);

            var result = new Password(salt, hash);

            return Result.Success(result);
        }

        public static Result<Password> Create(string salt, string password)
        {
            if (!IsPasswordValid(password))
                return Result.Failure(new InvalidPasswordLengthError(MimLength, MaxLength));

            var hash = GetHash(Convert.FromBase64String(salt), password);

            var result = new Password(salt, hash);

            return Result.Success(result);
        }

        private static bool IsPasswordValid(string password)
        {
            return password.Length >= MimLength || password.Length <= MaxLength;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Salt;
            yield return Hash;
        }

        private static string GetHash(byte[] salt, string source)
        {
            var hash = KeyDerivation.Pbkdf2(
                password: source!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(hash);
        }
    }
}
