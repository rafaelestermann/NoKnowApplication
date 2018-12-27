namespace ashtonapp.Database.Entities
{
    public class AssignmentDetailEntity
    {
        public virtual long AssignmentDetailID { get; set; }
        public virtual long Fk_AssignmentID { get; set; }
        public virtual string DetailSpecification { get; set; }
        public virtual string Category { get; set; }
        public virtual int KarmaValue { get; set; }
    }
}