﻿namespace Business.Responses.Objective
{
    public class GetObjectiveByIdResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}