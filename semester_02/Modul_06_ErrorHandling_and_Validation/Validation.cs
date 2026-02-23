using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
namespace Semester2.Parsing;

public struct ValidationResult
{
    public bool Ok {get; private set;}
    public string ErrorCode {get; private set;}
    public string Message {get; private set;}

    public ValidationResult (bool ok, string error, string message)
    {
        if (!ok && string.IsNullOrWhiteSpace(error))
        {
            throw new ArgumentException (nameof(error), "Error Code fehlt.");
        }

        Ok = ok;
        ErrorCode = error ?? "NONE";
        Message = message ?? "";
    }
    public static ValidationResult Success()
        {
            return new ValidationResult(true, "", "");
        }

    public static ValidationResult Failure(string code, string msg)
        {
            return new ValidationResult(false, code, msg);
        }        
}