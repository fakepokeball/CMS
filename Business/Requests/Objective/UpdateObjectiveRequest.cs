namespace Business.Requests.Objective
{
    public class UpdateObjectiveRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}