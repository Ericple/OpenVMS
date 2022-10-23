namespace OpenVMS.Auth;

//==================================================
// Auth permission carries:
// 1. Client authorization
//==================================================
public class AuthPermission
{
    private string Token;
    private string Identifier;
    private string ClientIdentifier;
    private bool Status;
}