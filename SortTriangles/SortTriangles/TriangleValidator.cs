using FluentValidation;

namespace SortTriangles
{
    class TriangleValidator : AbstractValidator<Triangle>
    {
        public TriangleValidator()
        {
            RuleFor(treangle => treangle.Name).NotEmpty();

            RuleFor(treangle => treangle.LengthOfTheFirstSide)
                .LessThan(treangle => treangle.LengthOfTheSecondSide + treangle.LengthOfTheThirdSide)
                .LessThan(treangle => double.MaxValue);

            RuleFor(treangle => treangle.LengthOfTheSecondSide)
                .LessThan(treangle => treangle.LengthOfTheFirstSide + treangle.LengthOfTheThirdSide)
                .LessThan(treangle => double.MaxValue);

            RuleFor(treangle => treangle.LengthOfTheThirdSide)
                .LessThan(treangle => treangle.LengthOfTheFirstSide + treangle.LengthOfTheSecondSide)
                .LessThan(treangle => double.MaxValue);
        }
    }
}
