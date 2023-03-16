namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.GenericVisitorPattern
{
    /// <summary>
    /// An object that can visit a Visitor.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// Call this script to "Visit" a visitor.
        /// </summary>
        /// <param name="_visitable">The visitable object we will be visiting.</param>
        void Visit(IVisitable _visitable);
    }
}
