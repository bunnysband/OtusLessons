namespace GuessTheNumber.Impl;

internal class MoreLessNumberValidator : INumberValidator
{
    private readonly int generatedNumber;
    public MoreLessNumberValidator(INumberGenerator numberGenerator)
    { 
        generatedNumber = numberGenerator.Generate();
    }

    public bool IsValid(int number, out string validationResult)
    {
        if (number < generatedNumber) 
        {
            validationResult = "Entered number is less than expected";
            return false;
        }
        else if (number > generatedNumber) 
        {
            validationResult = "Entered number is more than expected";
            return false;
        }
        validationResult = "Enters number is correct";
        return true;
    }
}
