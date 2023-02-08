﻿namespace ChallengeAPI.Application.Models
{
    public class Operation
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public double ValueOperation { get; set; }
        public DateTime Date { get; set; }
        public TypeOperation TypeOperation { get; set; }
    }
}
