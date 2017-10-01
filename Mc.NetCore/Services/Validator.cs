namespace Mc.NetCore.Services
{
    using Mc.NetCore.Abstractions;

    public class NumberValidator : IValidator
    {
        public bool Validate(string data)
        {
            return int.TryParse(data, out int result);
        }
    }
}
