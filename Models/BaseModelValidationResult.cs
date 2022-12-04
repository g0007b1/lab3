using System.Text;

namespace LW1.Models
{
    public class BaseModelValidationResult
    {
        private readonly StringBuilder _errorBuilder = new StringBuilder();

        public bool IsValid { get; private set; } = true;
        public string Errors => _errorBuilder.ToString().Trim();

        public void Append(string error)
        {
            IsValid = false;

            _errorBuilder.AppendLine(error);
        }
    }
}