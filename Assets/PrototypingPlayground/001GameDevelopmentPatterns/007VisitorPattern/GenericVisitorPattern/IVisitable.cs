namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.GenericVisitorPattern
{
    /// <summary>
    /// The object that Visitors can visit and modify.
    /// </summary>
    public interface IVisitable
    {
        /// <summary>
        /// This will accept the visitor.
        /// </summary>
        /// <param name="visitor">The visitor that will be visiting. This will most likely be itself.</param>
        void Accept(IVisitor visitor);
    }
}
