using System;

namespace LW1.Models
{
    public class Athlete
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public int Year { get; set; }

        public string Result { get; set; }

        public Guid Id { get; set; } = Guid.Empty;

        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();

            if (string.IsNullOrWhiteSpace(Surname)) validationResult.Append("Surname cannot be empty");

            if (string.IsNullOrWhiteSpace(Name)) validationResult.Append("Name cannot be empty");

            if (Year < 0) validationResult.Append("Year of birthday cannot be negative");

            return validationResult;
        }

        public override string ToString()
        {
            return $"Surname: {Surname} | Name: {Name} | Year: {Year} | Result: {Result}";
        }
    }
}