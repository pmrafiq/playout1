namespace TAS.Common.Interfaces.Security
{
    /// <summary>
    /// Access control list item
    /// </summary>
    public interface IAclRight
    {
        /// <summary>
        /// Object to which rights are controlled against
        /// </summary>
        IPersistent Owner { get; set; }

        /// <summary>
        /// Object that have rights to Owner
        /// </summary>
        ISecurityObject SecurityObject { get; set; }
        
        /// <summary>
        /// bit map of rights assigned for SecurityObject to Owner
        /// </summary>
        ulong Acl { get; set ;}
    }
}
