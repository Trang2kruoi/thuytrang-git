using Abp.Domain.Entities.Auditing;

namespace thuytrang.Reviews
{
    // Kế thừa FullAuditedEntity để tự động có các trường: CreationTime, CreatorUserId, IsDeleted...
    public class Review : FullAuditedEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}