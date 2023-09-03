namespace GuessTheNumber;

internal interface INumberValidator
{
   bool IsValid(int number, out string validationResult);
}
