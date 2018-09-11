namespace Rabbit.Communication.Mailing
{
    /// <summary>
    /// This will be used to transform a saved mail template into fields
    /// </summary>
    public interface IMailMessageTransformer
    {
        string GetSubject();

        /// <summary>
        /// Get subject and replaced variable (@Model.VariableName) by value in model
        /// </summary>
        string GetSubject(dynamic model);

        string GetHtmlBody();

        /// <summary>
        /// Get body and replaced variable (@Model.VariableName) by value in model
        /// </summary>
        string GetHtmlBody(dynamic model);
    }
}