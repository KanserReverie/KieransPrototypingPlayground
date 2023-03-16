namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.GenericVisitorPattern
{
    /// <summary>
    /// An object that can visit a Visitor.
    /// </summary>
    public interface IVisitor
    {
        
        /// <summary>
        /// Call this script to "Visit" a visitable FirstVisitableClass.
        /// </summary>
        /// <param name="_visitableExample">The visitable object of type [VisitableExampleClassFirst] we will be visiting.</param>
        void Visit(VisitableExampleClassFirst _visitableExample);
        
        
        /// <summary>
        /// Call this script to "Visit" a visitable VisitableExampleClassSecond.
        /// </summary>
        /// <param name="_visitableExample">The visitable object of type [VisitableExampleClassSecond] we will be visiting.</param>
        void Visit(VisitableExampleClassSecond _visitableExample);
        
        
        /// <summary>
        /// Call this script to "Visit" a visitable VisitableExampleClassThird.
        /// </summary>
        /// <param name="_visitableExample">The visitable object of type [VisitableExampleClassThird] we will be visiting.</param>
        void Visit(VisitableExampleClassThird _visitableExample);
        
    }
}
