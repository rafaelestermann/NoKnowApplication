namespace ashtonapp.Database.Entities
{
    public class WorkerEntity
    {
        public virtual long WorkerID { get; set; }
        public virtual string Workername { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Email { get; set; }
        public virtual int KarmaValue { get; set; }
    }
}