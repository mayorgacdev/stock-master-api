namespace Training.Application.Validations.Products;

using FluentValidation;
using FluentValidation.Validators;
using Training.Application.Constants;
using Training.Application.Requests.Products;
using Training.Application.Resources;

public class ProducPictureUniqueUrlValidator<T>
    : PropertyValidator<T, IEnumerable<CreateProductPictureRequest>>
{
    public override string Name => "ProducPictureUniqueUrlValidator";

    public override bool IsValid(ValidationContext<T> Context, IEnumerable<CreateProductPictureRequest> PicturesRequest)
    {
        var Values = PicturesRequest.DistinctBy(Request => Request.PictureUrl);
        return PicturesRequest.Count() == Values.Count(); 
    }

    protected override string GetDefaultMessageTemplate(string ErrorCode)
    {
        return ErrorCodeMessages.GetMessageFromCode(ErrorCodes.SERVC0006)!;
    }
}
